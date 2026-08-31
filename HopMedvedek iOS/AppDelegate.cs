using CoreMotion;
using Foundation;
using UIKit;

namespace HopMedvedekiOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    private global::HopMedvedek.HopMedvedek _game;
    private CMMotionManager _motion;

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        _game = new global::HopMedvedek.HopMedvedek();

        // Feed the device accelerometer into the shared tilt-steering code.
        // CoreMotion reports acceleration in g units, which is exactly what
        // HopControls.SetTilt expects.
        _motion = new CMMotionManager { AccelerometerUpdateInterval = 1.0 / 60.0 };
        StartMotion();

        // On iOS Game.Run() starts the display-link loop and returns; it does not block.
        _game.Run();
        return true;
    }

    private static void HandleAccelerometer(CMAccelerometerData data, NSError error)
    {
        if (data != null)
            global::HopMedvedek.Input.HopControls.SetTilt((float)data.Acceleration.X);
    }

    private void StartMotion()
    {
        if (_motion != null && _motion.AccelerometerAvailable && !_motion.AccelerometerActive)
            _motion.StartAccelerometerUpdates(NSOperationQueue.MainQueue, HandleAccelerometer);
    }

    public override void OnActivated(UIApplication application) => StartMotion();

    public override void OnResignActivation(UIApplication application) => _motion?.StopAccelerometerUpdates();
}
