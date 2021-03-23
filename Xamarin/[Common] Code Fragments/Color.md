### Xamarin.Forms.Color to Platform Color

- Android
```cs
using Xamarin.Forms.Platform.Android;
Android.Graphics.Color droidColor = formsColor.ToAndroid();
```

- iOS
```cs
UIKit.UIColor formsColor = yourXFColor.ToUIColor();
```
