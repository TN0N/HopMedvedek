# HopMedvedek iOS

iOS head project. Same structure as `HopMedvedek Android`: it does **not**
reference the desktop `.csproj`s, it link-compiles the shared `HopMedvedek/`,
`Express/`, `Artificial/` source against `MonoGame.Framework.iOS`.

## ⚠️ A runnable build needs macOS

Apple's toolchain (native AOT, `.app` bundling, code signing, the asset-catalog
compiler `actool`, and `mlaunch`/simulator) only runs on macOS. On **Windows** you
can restore packages and compile the **managed assembly**, but not produce an
`.ipa`/`.app`. To finish it you need one of:

- a **Mac** with Xcode + the .NET `ios` workload (`dotnet workload install ios`), or
- **Windows + Visual Studio "Pair to Mac"** (a networked Mac build host), or
- a **macOS CI runner** (e.g. GitHub Actions `macos-latest`).

## How it is wired

| Concern | Approach |
|---|---|
| MonoGame runtime | `MonoGame.Framework.iOS` 3.8.4.1 |
| Shared game code | link-compiled via `<Compile Include="..\…\**\*.cs" />` globs (see `.csproj`); `HopMedvedek/Program.cs` excluded |
| Target framework | `net9.0-ios`, `SupportedOSPlatformVersion` 13.0, portrait only |
| Entry point | `Program.Main` → `UIApplication.Main` → `AppDelegate.FinishedLaunching` news up `HopMedvedek.HopMedvedek` and calls `Run()` (non-blocking on iOS) |
| Content | prebuilt platform-neutral `.xnb` copied into `Content/`, shipped as `BundleResource` (`<bundle>/Content/…`); the same reuse as Android |
| Save data | shared `HopMedvedek/Data/DataStore.cs` - `#if ANDROID || IOS` branch writes to `Environment.SpecialFolder.LocalApplicationData` (the app's Library dir) and seeds first-run defaults from the bundle via `TitleContainer` |
| Display | `HopMedvedek.ApplyBackBufferSize()` `#if ANDROID || IOS` sets the back buffer to the native `CurrentDisplayMode` and `IsFullScreen`, so the render surface = the screen with no letterbox and touch maps 1:1 onto scene coords |
| Menu touch | shared `HopInput.cs` `#elif IOS` branch synthesises a `MouseState` from `TouchPanel.GetState()` (MonoGame feeds `UITouch` into it); `Button`/`Slider`/`Dropdown` are unchanged |
| Gameplay input | shared `HopControls.cs` `#elif IOS` branch - **tilt** via CoreMotion (`AppDelegate` starts `CMMotionManager` accelerometer updates → `HopControls.SetTilt`), **swipe up** = `TouchPanel` `Flick` (upward), **tap** = `TouchPanel` `Tap`. Same `TiltSign` / `TiltDeadzone` / `TiltFullAt` constants as Android. |
| Resolution option | compiled out on iOS (`#if !ANDROID && !IOS` in `OptionsMenu.cs`) |
| Icon | single 1024² placeholder in `Assets.xcassets/AppIcon.appiconset` (the catalog is only compiled on macOS) |

## Testing on an iPhone from Windows (no Mac)

`.github/workflows/ios-ipa.yml` builds an **unsigned `.ipa`** on a GitHub
`macos-15` runner and uploads it as an artifact. Then:

1. Actions tab → **iOS .ipa (unsigned, for sideloading)** → *Run workflow*
   (or it runs automatically on push to `main`). Download the
   `HopMedvedek-iOS-unsigned-ipa` artifact and unzip it.
2. On the PC, install **[Sideloadly](https://sideloadly.io)** or
   **AltStore + AltServer for Windows**. Plug in the iPhone, sign in with your
   Apple ID (free is fine), drop in `HopMedvedek.iOS.ipa`, Start. The tool
   re-signs it and installs it.
3. On the iPhone: Settings → General → VPN & Device Management → trust the
   developer profile; Settings → Privacy & Security → **Developer Mode** → on
   (iOS 16+), then reboot.
4. The app runs for **7 days** (free Apple ID limit). Re-sideload to renew;
   AltStore can auto-refresh while AltServer is running.

No Apple Developer account, no signing secrets, no Mac. The CI just needs the
repo's `ios` workload, which `dotnet workload restore` pulls on the runner.

## Build (on a Mac / paired Mac / macOS CI)

```bash
dotnet workload install ios          # once
dotnet build "HopMedvedek iOS/HopMedvedek.iOS.csproj" -c Debug          # simulator, unsigned
# device / .ipa:
dotnet publish "HopMedvedek iOS/HopMedvedek.iOS.csproj" -c Release -r ios-arm64 \
  -p:CodesignKey="Apple Development: …" -p:CodesignProvision="…"
```

Run in the simulator:

```bash
dotnet build "HopMedvedek iOS/HopMedvedek.iOS.csproj" -t:Run -c Debug \
  -p:_DeviceName=:v2:udid=<simulator-udid>
```

## Verified on Windows

`dotnet build -c Debug` restores `MonoGame.Framework.iOS`, compiles the shared
game + engine + the iOS input plumbing against the real iOS SDK, and emits
`bin/Debug/net9.0-ios/iossimulator-x64/HopMedvedek.iOS.dll` with **0 errors**.
It stops before the `.app` (asset-catalog compile, native AOT link, signing) —
that is the macOS-only step.

Touch / tilt runtime behaviour is unverified; it mirrors the Android
implementation, which was tested on an emulator.

## Known gaps

- `TiltSign` may need flipping after a real-device check (CoreMotion axis sign),
  same caveat as Android.
- `Content/` duplicates ~76 MB of `.xnb` already under `HopMedvedek/bin/`.
- Placeholder app icon; no custom launch screen (uses the empty `UILaunchScreen`).
- Release/AOT/bitcode/signing config is left to the Mac side.
