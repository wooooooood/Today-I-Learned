# `IsEnabled = False` Not working 
**Case.** 페이지 시작시, 아래 두 경우에 Binding값에 상관없이 버튼이 항상 `Enabled`상태로 나타났다.
```xml
<Button Text="Press" 
        IsEnabled="{Binding IsPressButtonEnabled}" 
        Command="{Binding MyCommand}"/>
<Button Text="Press2" 
        IsEnabled="False" 
        Command="{Binding MyCommand2}"/>
```
**Solution 1.** Command property가 설정되지 않으면 항상 Enabled상태이므로, `CanExecute`에 대한 Property를 추가한다.
https://forums.xamarin.com/discussion/47857/setting-buttons-isenabled-to-false-does-not-disable-button
```cs
private Command _PressCommand;
public Command PressCommand
{
  get
  {
    /*the false returned in second constructor parameter will mean that button bound to this command 
    will always be disabled; please change to your logic eg IsBusy view model property*/
    return _PressCommand ?? (_PressCommand = 
      new Command(
        execute: () => ExecutePressCommand(), 
        canExecute: () => false )
      );
    ); 
  }
}
```

**Solution 2.** xaml의 순서를 변경한다.
https://github.com/xamarin/Xamarin.Forms/issues/6991#issuecomment-787463284
```xml
<Button Text="Press" 
        Command="{Binding MyCommand}"
        IsEnabled="{Binding IsPressButtonEnabled}" />
```
