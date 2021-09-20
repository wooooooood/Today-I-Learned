`DependencyService` class is a service locator that enables Xamarin.Forms applications to invoke native platform functionality from shared code.

### 1. Create interface
```cs
public interface IDeviceOrientationService
{
    DeviceOrientation GetOrientation();
}
```

### 2. Implement Android
```cs
[assembly: Dependency(typeof(DependencyServiceDemos.Droid.DeviceOrientationService))]
namespace DependencyServiceDemos.Droid
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 ||
                orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;
        }
    }
}
```

### 3. Implement iOS
```cs
[assembly: Dependency(typeof(DependencyServiceDemos.iOS.DeviceOrientationService))]
namespace DependencyServiceDemos.iOS
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            bool isPortrait = orientation == UIInterfaceOrientation.Portrait ||
                orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}
```
- Register on `AppDelegate.FinishedLaunching`
```cs
DependencyService.Register<IDeviceOrientationService, DeviceOrientationService>();
```

### 4. Use
```cs
DeviceOrientation orientation = DependencyService.Get<IDeviceOrientationService>().GetOrientation();
```
