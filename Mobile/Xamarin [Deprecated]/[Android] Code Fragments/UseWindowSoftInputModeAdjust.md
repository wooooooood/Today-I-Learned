- 기본적으로 이걸 사용하면 키보드가 열렸을 때 페이지가 줄어들어 fit된다.
- 함정은 AppShell을 쓰는 경우 Shell Tab과 함께 쭈그러들어서 보여지는 화면이 더욱 좁아진다는것이다..
```cs
Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
```

- 그래서 특정 페이지에서만 soft keyboard를 사용하고 싶을 때는 https://stackoverflow.com/a/49123024
```cs
protected override void OnAppearing()
{
    base.OnAppearing();
    App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
} 

protected override void OnDisappearing()
{
    base.OnDisappearing();
    App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
}
```
