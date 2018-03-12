# SimulatorStatusMagicXamarinBindings
Xamarin.iOS bindings for https://github.com/shinydevelopment/SimulatorStatusMagic


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
