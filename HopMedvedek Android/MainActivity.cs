using Android.App;
using Android.Content.PM;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Microsoft.Xna.Framework;

namespace HopMedvedekDroid;

[Activity(
    Label = "Hop Medvedek",
    MainLauncher = true,
    Icon = "@mipmap/icon",
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ScreenOrientation = ScreenOrientation.Portrait,
    ConfigurationChanges = ConfigChanges.Orientation
        | ConfigChanges.Keyboard
        | ConfigChanges.KeyboardHidden
        | ConfigChanges.ScreenSize
        | ConfigChanges.ScreenLayout
        | ConfigChanges.UiMode)]
public class MainActivity : AndroidGameActivity, ISensorEventListener
{
    private global::HopMedvedek.HopMedvedek _game;
    private View _view;

    private SensorManager _sensorManager;
    private Sensor _accelerometer;

    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        Window?.AddFlags(WindowManagerFlags.Fullscreen);

        _sensorManager = (SensorManager)GetSystemService(SensorService);
        _accelerometer = _sensorManager?.GetDefaultSensor(SensorType.Accelerometer);

        _game = new global::HopMedvedek.HopMedvedek();
        _view = _game.Services.GetService(typeof(View)) as View;

        SetContentView(_view);
        _game.Run();
    }

    protected override void OnResume()
    {
        base.OnResume();
        if (_accelerometer != null)
            _sensorManager.RegisterListener(this, _accelerometer, SensorDelay.Game);
    }

    protected override void OnPause()
    {
        base.OnPause();
        _sensorManager?.UnregisterListener(this);
    }


    public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
    {
    }

    public void OnSensorChanged(SensorEvent e)
    {
        if (e?.Sensor?.Type != SensorType.Accelerometer || e.Values == null || e.Values.Count < 1)
            return;

        float gravityFraction = e.Values[0] / SensorManager.GravityEarth;
        global::HopMedvedek.Input.HopControls.SetTilt(gravityFraction);
    }

    public override bool DispatchTouchEvent(MotionEvent e)
    {
        global::HopMedvedek.Input.HopInput.FeedTouch(e);
        global::HopMedvedek.Input.HopControls.FeedTouch(e);
        return base.DispatchTouchEvent(e);
    }
}
