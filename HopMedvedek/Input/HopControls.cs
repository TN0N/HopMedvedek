#if ANDROID
using Android.Views;
#endif
#if IOS
using Microsoft.Xna.Framework.Input.Touch;
#endif
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HopMedvedek.Input;

/// <summary>
/// Platform-neutral surface for the three in-game controls, so <c>Player</c>
/// does not need per-platform branches:
///
/// <list type="bullet">
///   <item><see cref="ConsumeStart"/> - start / kick off the auto-bounce.
///     Desktop: <c>Space</c>. Mobile: swipe up.</item>
///   <item><see cref="ConsumeThrow"/> - throw a pinecone toward a screen point.
///     Desktop: left mouse button. Mobile: tap.</item>
///   <item><see cref="HorizontalAcceleration"/> - left/right drive.
///     Desktop: <c>A</c> / <c>D</c>. Mobile: device tilt (accelerometer).</item>
/// </list>
///
/// The mobile head projects feed raw accelerometer through <see cref="SetTilt"/>
/// (Android from <c>DispatchTouchEvent</c> also feeds touch via
/// <see cref="FeedTouch"/>; iOS reads MonoGame's <c>TouchPanel</c> directly).
/// </summary>
public static class HopControls
{
    /// <summary>-1 = full left, +1 = full right, 0 = centred / desktop.</summary>
    public static float TiltX { get; private set; }

#if ANDROID || IOS
    // === tilt (accelerometer) - shared ===================================

    // "Tilt right" = dip the right edge down (accel X goes negative) -> move right.
    // Flip to +1f if a device/user wants the opposite.
    private const float TiltSign = -1f;
    private const float TiltDeadzone = 0.05f;   // fraction of g ignored around flat
    private const float TiltFullAt = 0.25f;     // fraction of g (~33 deg) for full speed

    /// <param name="gravityFraction">
    /// Accelerometer X in units of g. Flat (roll = 0) is always the centre, so
    /// starting a run while the device is rolled to one side just steers the bear
    /// that way - it is not taken as the new neutral.
    /// </param>
    public static void SetTilt(float gravityFraction)
    {
        float v = TiltSign * gravityFraction;
        float sign = v < 0f ? -1f : 1f;
        float magnitude = Math.Abs(v) - TiltDeadzone;
        if (magnitude <= 0f)
        {
            TiltX = 0f;
            return;
        }
        TiltX = MathHelper.Clamp(sign * magnitude / (TiltFullAt - TiltDeadzone), -1f, 1f);
    }

    public static float HorizontalAcceleration(float maxAcceleration) => TiltX * maxAcceleration;

    // === gestures (start = swipe up, throw = tap) - shared state ==========

    private static readonly object _gate = new object();
    private static bool _tapPending;
    private static bool _swipeUpPending;
    private static float _tapX, _tapY;

    /// <summary>Drop any gesture picked up before a level starts (e.g. the menu tap).</summary>
    public static void ResetGestures()
    {
        PollGestures();
        lock (_gate)
        {
            _tapPending = false;
            _swipeUpPending = false;
#if ANDROID
            _tracking = false;
#endif
        }
    }

    public static bool ConsumeStart()
    {
        PollGestures();
        lock (_gate)
        {
            bool v = _swipeUpPending;
            _swipeUpPending = false;
            return v;
        }
    }

    public static bool ConsumeThrow(out Vector2 screenPosition)
    {
        PollGestures();
        lock (_gate)
        {
            if (_tapPending)
            {
                _tapPending = false;
                screenPosition = new Vector2(_tapX, _tapY);
                return true;
            }
        }
        screenPosition = Vector2.Zero;
        return false;
    }

#if ANDROID
    // --- Android: gestures are pushed from Activity.DispatchTouchEvent -----

    private const long TapMaxMs = 250;      // press shorter than this...
    private const float TapSlopPx = 48f;    // ...and moving less than this = tap
    private const float SwipeUpMinPx = 110f;

    private static bool _tracking;
    private static float _downX, _downY;
    private static long _downTime;

    private static void PollGestures()
    {
        // Nothing to poll - FeedTouch pushes gestures as events arrive.
    }

    /// <summary>Feed a raw Android touch event (from <c>Activity.DispatchTouchEvent</c>).</summary>
    public static void FeedTouch(MotionEvent e)
    {
        if (e == null)
            return;

        lock (_gate)
        {
            switch (e.ActionMasked)
            {
                case MotionEventActions.Down:
                    _tracking = true;
                    _downX = e.GetX();
                    _downY = e.GetY();
                    _downTime = e.EventTime;
                    break;

                case MotionEventActions.Up:
                    if (!_tracking)
                        break;
                    _tracking = false;

                    float upX = e.GetX();
                    float upY = e.GetY();
                    float dx = upX - _downX;
                    float dy = upY - _downY;
                    long dt = e.EventTime - _downTime;

                    if (dt <= TapMaxMs && Math.Abs(dx) <= TapSlopPx && Math.Abs(dy) <= TapSlopPx)
                    {
                        _tapPending = true;
                        _tapX = upX;
                        _tapY = upY;
                    }
                    else if (dy <= -SwipeUpMinPx && Math.Abs(dy) > Math.Abs(dx))
                    {
                        _swipeUpPending = true;
                    }
                    break;

                case MotionEventActions.Cancel:
                    _tracking = false;
                    break;
            }
        }
    }

#elif IOS
    // --- iOS: read MonoGame's TouchPanel gesture recogniser --------------

    private const float SwipeUpMinFlickVelocity = 700f;   // px/s, upward

    static HopControls()
    {
        TouchPanel.EnabledGestures = GestureType.Tap | GestureType.Flick;
    }

    private static void PollGestures()
    {
        while (TouchPanel.IsGestureAvailable)
        {
            GestureSample g = TouchPanel.ReadGesture();

            if (g.GestureType == GestureType.Tap)
            {
                lock (_gate)
                {
                    _tapPending = true;
                    _tapX = g.Position.X;
                    _tapY = g.Position.Y;
                }
            }
            else if (g.GestureType == GestureType.Flick
                     && g.Delta.Y <= -SwipeUpMinFlickVelocity
                     && Math.Abs(g.Delta.Y) > Math.Abs(g.Delta.X))
            {
                lock (_gate)
                {
                    _swipeUpPending = true;
                }
            }
        }
    }
#endif

#else
    // === desktop: keyboard + mouse (unchanged behaviour) ================

    public static float HorizontalAcceleration(float maxAcceleration)
    {
        KeyboardState k = Keyboard.GetState();
        float direction = 0f;
        if (k.IsKeyDown(Keys.A))
            direction -= 1f;
        if (k.IsKeyDown(Keys.D))
            direction += 1f;
        return direction * maxAcceleration;
    }

    public static bool ConsumeStart() => Keyboard.GetState().IsKeyDown(Keys.Space);

    public static bool ConsumeThrow(out Vector2 screenPosition)
    {
        MouseState m = Mouse.GetState();
        if (m.LeftButton == ButtonState.Pressed)
        {
            screenPosition = m.Position.ToVector2();
            return true;
        }
        screenPosition = Vector2.Zero;
        return false;
    }

    public static void FeedTouch(object e)
    {
    }

    public static void ResetGestures()
    {
    }
#endif
}
