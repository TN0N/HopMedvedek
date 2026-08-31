#if ANDROID
using Android.Views;
#endif
#if IOS
using Microsoft.Xna.Framework.Input.Touch;
#endif
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HopMedvedek.Input;

/// <summary>
/// Cross-platform pointer input for the GUI layer.
///
/// On desktop this is a thin pass-through to <see cref="Mouse"/>.
///
/// On mobile there is no mouse; MonoGame does not feed <see cref="Mouse"/> from
/// touch, so the existing <c>Mouse.GetState()</c>-based UI (Button / Slider /
/// Dropdown) never sees a click. A <see cref="MouseState"/> is synthesised from
/// touch instead - on Android from raw <c>MotionEvent</c>s the Activity forwards
/// through <c>FeedTouch</c>, on iOS from MonoGame's <c>TouchPanel</c>. Either way
/// the coordinates are in the same
/// back-buffer space <c>Mouse.GetState().Position</c> uses on desktop, so the
/// existing inverse-view hit-testing works unchanged.
/// </summary>
public static class HopInput
{
#if ANDROID
    private enum Phase { None, Down, Up }

    private static Phase _phase = Phase.None;
    private static int _x;
    private static int _y;
    private static readonly object _gate = new object();

    /// <summary>
    /// Forward a raw Android touch event. Call this from
    /// <c>Activity.DispatchTouchEvent</c>.
    /// </summary>
    public static void FeedTouch(MotionEvent e)
    {
        if (e == null)
            return;

        lock (_gate)
        {
            int pointer = e.ActionIndex;
            _x = (int)e.GetX(pointer);
            _y = (int)e.GetY(pointer);

            switch (e.ActionMasked)
            {
                case MotionEventActions.Down:
                    _phase = Phase.Down;
                    break;
                case MotionEventActions.PointerDown:
                case MotionEventActions.Move:
                    _phase = Phase.Down;
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.PointerUp:
                case MotionEventActions.Cancel:
                case MotionEventActions.Outside:
                    _phase = Phase.Up;
                    break;
            }
        }
    }

    public static MouseState GetMouseState()
    {
        lock (_gate)
        {
            ButtonState left = _phase == Phase.Down ? ButtonState.Pressed : ButtonState.Released;
            return new MouseState(_x, _y, 0, left,
                ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
    }

    /// <summary>
    /// Ends the one-frame "released" pulse. Call once per frame, after every
    /// component has updated (see <c>HopMedvedek.Update</c>).
    /// </summary>
    public static void EndFrame()
    {
        lock (_gate)
        {
            if (_phase == Phase.Up)
                _phase = Phase.None;
        }
    }

#elif IOS
    private enum Phase { None, Down, Up }

    private static Phase _phase = Phase.None;
    private static int _x;
    private static int _y;

    // MonoGame forwards UITouch events into TouchPanel on iOS. Positions are in
    // back-buffer space which, with the native-resolution back buffer, matches
    // Game.Window.ClientBounds - the space the desktop Mouse position uses.
    public static MouseState GetMouseState()
    {
        TouchCollection touches = TouchPanel.GetState();

        bool active = false;
        for (int i = 0; i < touches.Count; i++)
        {
            TouchLocation t = touches[i];
            _x = (int)t.Position.X;
            _y = (int)t.Position.Y;

            if (t.State == TouchLocationState.Pressed || t.State == TouchLocationState.Moved)
            {
                _phase = Phase.Down;
                active = true;
                break;
            }
            if (t.State == TouchLocationState.Released)
                _phase = Phase.Up;
        }
        if (!active && _phase == Phase.Down)
            _phase = Phase.Up;   // touch vanished without a Released frame

        ButtonState left = _phase == Phase.Down ? ButtonState.Pressed : ButtonState.Released;
        return new MouseState(_x, _y, 0, left,
            ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
    }

    public static void EndFrame()
    {
        if (_phase == Phase.Up)
            _phase = Phase.None;
    }

#else
    public static MouseState GetMouseState() => Mouse.GetState();

    public static void EndFrame()
    {
    }
#endif
}
