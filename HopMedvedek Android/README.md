# HopMedvedek Android

Android head project for the game. It is **self-contained**: it does not modify or
reference the desktop `.csproj` files. Building this project produces an installable
`.apk`.

## How it is wired

| Concern | Approach |
|---|---|
| MonoGame runtime | `MonoGame.Framework.Android` 3.8.4.1 (the desktop projects use `MonoGame.Framework.DesktopGL`, which cannot be linked into the same app). |
| Shared game code | `HopMedvedek/`, `Express/`, `Artificial/` `.cs` files are **link-compiled** into this project (see the `<Compile Include="..\…" />` globs in the `.csproj`). `HopMedvedek/Program.cs` is excluded — the entry point on Android is `MainActivity`. |
| Target framework | `net9.0-android` (compile SDK 35, `minSdkVersion` 21). |
| Display | `HopMedvedek.ApplyBackBufferSize()` sets the back buffer to `GraphicsAdapter.DefaultAdapter.CurrentDisplayMode` and `IsFullScreen = true` on Android (`#if ANDROID`); `MainActivity` also sets `WindowManagerFlags.Fullscreen`. So the render surface = the device's native resolution with no status/nav-bar inset and no letterbox, and the 408x906 design space (`HopMedvedekConstants.screenWidth/Height`) stretches to fill it. This is what makes screen-space taps line up with scene coordinates — the camera matrices already divide by `ClientBounds`, which is now the full screen. The resolution picker in the options menu is compiled out on Android (`#if !ANDROID` in `OptionsMenu.cs`). Desktop still honours the user-chosen resolution from `options.json`. |
| Content | The desktop `.mgcb` pipeline needs a `LocalizedFontProcessor` extension that is not in the repo, so content is **not** rebuilt here. The prebuilt, platform-neutral `.xnb` from the desktop build (`HopMedvedek/bin/Debug/net8.0/Content/`) were copied into `Content/` and are shipped as `assets/Content/`. Textures are uncompressed `Color`, sounds are PCM, so they load unchanged on Android GL. |
| Save data | Desktop wrote JSON next to the executable, which is impossible on Android. `HopMedvedek/Data/DataStore.cs` (new, shared) routes reads/writes: on desktop it is a pass-through to `File.*`; under `#if ANDROID` it writes to app-private storage and seeds first-run defaults from `assets/Data/*` + `assets/Options/*`. `PlayerData.cs`, `Options.cs`, `Shop.cs` call `DataStore` instead of `File` directly. Desktop behaviour is byte-for-byte unchanged. |
| Input (menus) | Adapted. `HopMedvedek/Input/HopInput.cs` (new, shared) synthesises a `MouseState` from raw Android touch events, fed by `MainActivity.DispatchTouchEvent`. `Button` / `Slider` / `Dropdown` call `HopInput.GetMouseState()` instead of `Mouse.GetState()`; `HopMedvedek.Update` calls `HopInput.EndFrame()` once per frame to end the one-frame release pulse. On desktop `HopInput` is a pass-through to `Mouse` — behaviour unchanged. Verified on the emulator: menu navigation forward and back works with correct press/hover feedback. |
| Input (gameplay) | Adapted. `HopMedvedek/Input/HopControls.cs` (new, shared) is the platform-neutral surface `Player` reads: desktop = `Space` / `A`,`D` / left-click; Android = **swipe up** to start the bounce, **device tilt** to move left/right (accelerometer, fed by `MainActivity.OnSensorChanged`), **tap** to throw a pinecone. `Player.cs` calls `HopControls.ConsumeStart()` / `HorizontalAcceleration()` / `ConsumeThrow()` instead of `Keyboard`/`Mouse`. Verified on the emulator: swipe starts the climb, tilt steers onto branches, tap throws (pinecone count drops). Tilt centre is a fixed reference (device roll = 0), so starting a run while rolled to one side simply steers that way rather than being taken as the new neutral. Tunables at the top of `HopControls.cs`: `TiltSign` (flip if tilt feels reversed on a device), `TiltDeadzone` / `TiltFullAt` (sensitivity), `TapMaxMs` / `TapSlopPx` / `SwipeUpMinPx` (gesture thresholds). |

## Build

```bash
dotnet build "HopMedvedek Android/HopMedvedek.Android.csproj" -c Debug \
  -p:AndroidSdkDirectory="%LOCALAPPDATA%\Android\Sdk" \
  -p:JavaSdkDirectory="C:\Program Files\Java\jdk-21.0.10"
```

Requires: .NET `android` workload, Android SDK platform + build-tools 35, a JDK in
the 17–21 range. Output:

```
bin/Debug/net9.0-android/com.tn0n.hopmedvedek-Signed.apk   (debug-keystore signed, installable)
bin/Debug/net9.0-android/com.tn0n.hopmedvedek.apk          (unsigned)
```

ABIs in the debug APK: `arm64-v8a` (devices) and `x86_64` (emulator).

## Install / run

```bash
adb install -r "bin/Debug/net9.0-android/com.tn0n.hopmedvedek-Signed.apk"
adb shell monkey -p com.tn0n.hopmedvedek -c android.intent.category.LAUNCHER 1
```

Or deploy straight from the SDK:

```bash
dotnet build "HopMedvedek Android/HopMedvedek.Android.csproj" -t:Run \
  -p:AndroidSdkDirectory="%LOCALAPPDATA%\Android\Sdk" \
  -p:JavaSdkDirectory="C:\Program Files\Java\jdk-21.0.10"
```

### Emulator

An x86_64 AVD named `HopMedvedek_x64` (Pixel 5, API 35) was created for testing:

```bash
%LOCALAPPDATA%\Android\Sdk\emulator\emulator.exe -avd HopMedvedek_x64
```

## Tested

Verified on the `HopMedvedek_x64` emulator (Android 15, x86_64), no crashes:

- App installs, launches, main menu renders — background art, `DynaPuff` font,
  Slovene localization, OpenAL audio all initialize.
- **Menu touch**: forward + back navigation works with press/hover feedback.
- **Gameplay**: swipe up starts the climb (score rises); device tilt
  (`adb emu sensor set acceleration x:y:z`) steers the bear onto branches; tap
  throws a pinecone (count decrements, projectile spawns).

## Known gaps (not blockers for building)

- Release build (`-c Release`, AAB, per-abi, R8 shrinking) not configured.
- Launcher icon is a generated placeholder (`Resources/mipmap-*/icon.png`).
- `Content/` duplicates ~76 MB of `.xnb` already present under `HopMedvedek/bin/`. If the desktop content pipeline is ever fixed, switch this project to a real `MonoGameContentReference` with `/platform:Android`.
- `EmbedAssembliesIntoApk=true` makes the APK self-contained (~112 MB) but slows incremental
  deploys; drop it and use `-t:Run` for a faster inner loop.
