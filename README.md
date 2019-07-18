# Simulator Status Magic - Xamarin.iOS Bindings

[![Latest version](https://img.shields.io/nuget/v/Xamarin.iOS.SimulatorStatusMagic.svg)](https://www.nuget.org/packages/Xamarin.iOS.SimulatorStatusMagic/) [![Downloads from NuGet](https://img.shields.io/nuget/dt/Xamarin.iOS.SimulatorStatusMagic.svg)](https://www.nuget.org/packages/Xamarin.iOS.SimulatorStatusMagic/)

This repo contains Xamarin.iOS bindings for [Simulator Status Magic](https://github.com/shinydevelopment/SimulatorStatusMagic).

Simulator Status Magic modifies the iOS Simulator so that it has a perfect status bar, then run your app and take perfect screenshots every time. The modifications made are designed to match the images you see on the Apple site and are as follows:

- 9:41 AM is displayed for the time.
- The battery is full and shows 100%.
- 5 bars of cellular signal and full WiFi bars are displayed.
- Tue Jan 9 is displayed for the date (iPad only)

And the library is configurable to fit all your status bar needs.

## Usage

1. Clone the this repo.
2. Build the solution.
3. Add the DLL as a reference to your Xamarin iOS project.
4. Modify your main method to enable the magic while running in the simulator:

```csharp
static void Main(string[] args) {
#if SIMULATOR
  SDStatusBarManager.SharedInstance.BatteryDetailEnabled = false;
  SDStatusBarManager.SharedInstance.EnableOverrides();
#endif
```

## Configuration

TO BE ADDED
