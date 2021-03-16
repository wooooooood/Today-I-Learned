# System.InvalidOperationException

### 'PushAsync is not supported globally on Android, please use a NavigationPage.'
- Navigation page로 시작하지 않고 `Navigation.PushAsync(new PageB())` 했을 때 발생
- Navigation page should be started
```
MainPage = new NavigationPage(new PageA());
```
> https://stackoverflow.com/a/37244322  
