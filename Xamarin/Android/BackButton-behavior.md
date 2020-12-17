iOS는 Backbutton이 없기 때문에 Android-specific한 기능으로 파악된다.  
구현하다보니 BackButtonPressed 이벤트를 여러군데에서 override하게 되는데 헷갈려서 정리한다.

### 1. MainActivity.cs
Android specific page이며 hardware backbutton을 눌렀을 때 여기로 직행한다.  
여기에서 `base.OnBackPressed()`를 호출하면 `AppShell.OnBackButtonPressed()`가 호출된다.  
그냥 return해버릴 수도 있다.
```cs
public override void OnBackPressed()
{
  if (DoNotCallBase)
    return;

  base.OnBackPressed();
}
```

### 2. AppShell.cs  
여기에서 반환하는 값에 따라 최종 action이 결정된다.  
최종 action이란 앱에 머무를지 말지를 의미한다.  
XF5-pre5 기준으로 `true`를 반환하면 앱에 머무르며, `false`를 반환하면 앱이 종료된다.  
```cs
protected override bool OnBackButtonPressed()
{
  if (StayOnApp) 
  {
    return true;
  }
  else if (StayOnAppButPopSomePage) 
  {
    Navigation.PopAsync();
    return true;
  }
  else if (StayOnAppButDoSomethingPageSpecific) 
  {
    var page = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
    return page.SendBackButtonPressed();
  }
  else
    return false;
}
```

### 3. SomePage.cs  
AppShell에서 호출한 `page.SendBackButtonPressed()`에 의해 호출된다.  
Page specific한 로직을 처리할 때 사용한다.  
```cs
protected override bool OnBackButtonPressed()
{
    return DoSomePageSpecificLogic();
}
```
