using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace SimulatorStatusMagicBindings
{
    //[Static]
    //partial interface Constants
    //{
    //    // extern double SimulatorStatusMagiciOSVersionNumber;
    //    [Field("SimulatorStatusMagiciOSVersionNumber", "__Internal")]
    //    double SimulatorStatusMagiciOSVersionNumber { get; }

    //    // extern const unsigned char [] SimulatorStatusMagiciOSVersionString;
    //    [Field("SimulatorStatusMagiciOSVersionString", "__Internal")]
    //    byte[] SimulatorStatusMagiciOSVersionString { get; }
    //}

    // @interface SDStatusBarManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SDStatusBarManager
    {
        // @property (copy, nonatomic) NSString * carrierName;
        [Export("carrierName")]
        string CarrierName { get; set; }

        // @property (copy, nonatomic) NSString * timeString;
        [Export("timeString")]
        string TimeString { get; set; }

        // @property (readonly, assign, nonatomic) BOOL usingOverrides;
        [Export("usingOverrides")]
        bool UsingOverrides { get; }

        // @property (assign, nonatomic) SDStatusBarManagerBluetoothState bluetoothState;
        [Export("bluetoothState", ArgumentSemantic.Assign)]
        SDStatusBarManagerBluetoothState BluetoothState { get; set; }

        // @property (assign, nonatomic) BOOL batteryDetailEnabled;
        [Export("batteryDetailEnabled")]
        bool BatteryDetailEnabled { get; set; }

        // -(void)enableOverrides;
        [Export("enableOverrides")]
        void EnableOverrides();

        // -(void)disableOverrides;
        [Export("disableOverrides")]
        void DisableOverrides();

        // +(SDStatusBarManager *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        SDStatusBarManager SharedInstance { get; }
    }

}
