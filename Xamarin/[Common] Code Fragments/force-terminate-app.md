# Force-Terminate app
https://stackoverflow.com/a/38203942


### Interface
```cs
public interface ICloseApplication
{
  void closeApplication();
}
```

### Android
Using `FinishAffinity()` won't restart your activity. It will simply close the application.
```cs
public class CloseApplication : ICloseApplication
{
  public void closeApplication()
  {
    var activity = (Activity)Forms.Context;
    activity.FinishAffinity();
  }
}
```

### IOS
App can be rejected by iOS policy.
```cs
public class CloseApplication : ICloseApplication
{
  public void closeApplication()
  {
    Thread.CurrentThread.Abort();
  }
}
```

### Usage in Xamarin Forms
```cs
var closer = DependencyService.Get<ICloseApplication>();
closer?.closeApplication();
```
