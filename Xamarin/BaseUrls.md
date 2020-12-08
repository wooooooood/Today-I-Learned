Need `Dependency service`
```cs
public interface IBaseUrl { string Get(); }
```
### Android
```cs
[assembly: Dependency (typeof(BaseUrl_Android))]
namespace WorkingWithWebview.Android
{
  public class BaseUrl_Android : IBaseUrl
  {
    public string Get() //Assets
    {
      return "file:///android_asset/";
    }
  }
}
```

### iOS
```cs
[assembly: Dependency (typeof (BaseUrl_iOS))]
namespace WorkingWithWebview.iOS
{
  public class BaseUrl_iOS : IBaseUrl
  {
    public string Get() //Resources
    {
      return NSBundle.MainBundle.BundlePath;
    }
  }
}
```
