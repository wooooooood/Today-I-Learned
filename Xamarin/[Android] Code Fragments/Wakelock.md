# Wakelock

- Add in `AndroidManifest.xml` inside `<manifest>`
```xml
<uses-permission android:name="android.permission.WAKE_LOCK" />
```

- `.Android` project
```cs
var service = (PowerManager)ApplicationContext.GetSystemService(PowerService);
var wakelock = service.NewWakeLock(WakeLockFlags.Full | WakeLockFlags.AcquireCausesWakeup, "Tag");
wakelock.Acquire();
//some code?
wakelock.Release();
```
