# 3+Button Alert Dialog
- Xamarin에서는 3개 이상의 버튼을 가진 `alert dialog`는 platform specific하게 구현해야 한다.
- 몇몇 소스를 참고하여 **재사용** 가능한 3개 이상 버튼을 지원하는 `alert dialog`를 custom하게 만들고자 한다.


## Common/Interface: ICustomAlertManager
iOS와 Android의 버튼 타입이 달라서 의미에 맞는 버튼을 공통으로 만드는게 어려웠다. (그래서 xamarin에서 공통으로 쓸수있는거 지원안하는거겠지..) 더 좋은 방법이 있으면 수정하자
```cs
public enum AndroidButtonType
{
    Positive,
    Neutral,
    Negative,
}

public enum iOSButtonType
{
    Default,
    Destructive,
    Cancel,
}

public class AlertButton
{
    public string Text { get; set; }
    public AndroidButtonType AndroidButtonType { get; set; }
    public iOSButtonType iOSButtonType { get; set; }
    public Action Action { get; set; }
    public Func<Task> ActionAsync { get; set; }
}

public interface ICustomAlertManager
{
    void Show(string title, string message, List<AlertButton> buttonList);
}
```

## Common/Page: MyPage.cs
`ShowCustomAlertDialog`에서는 custom한 3버튼 alert dialog를 생성, 띄운다.
```cs
public void ShowCustomAlertDialog()
{
    DependencyService.Get<ICustomAlertManager>().Show("이것은 버튼이 세개다", "확인해봐라",
    new List<AlertButton>() {
    new AlertButton
    {
        Text="깃헙을 열자",
        AndroidButtonType = AndroidButtonType.Positive,
        iOSButtonType = iOSButtonType.Default,
        ActionAsync = async () => { await Browser.OpenAsync("https://github.com/wooooooood/", BrowserLaunchMode.SystemPreferred); }
    },
    new AlertButton
    {
        Text = "Alert dialog 닫기",
        AndroidButtonType = AndroidButtonType.Neutral,
        iOSButtonType = iOSButtonType.Cancel,
    },
    new AlertButton
    {
        Text="뭔가 파괴적이고 부정적인 행위,,",
        AndroidButtonType = AndroidButtonType.Negative,
        iOSButtonType = iOSButtonType.Destructive,
        Action = () => { throw new NotImplementedException(); }
    }
    });
}
```
  
## Android/Dependency: CustomAlertManager.cs
Android에는 `activity context`와 `application context`가 있는데 alert dialog의 경우에는 toast message처럼 앱의 어디에서나 글로벌하게 나타나지 않아 `activity context`를 사용해야 한다. `activity context`를 저장, 불러오는 방법은 따로 구현해야 하며 아래 코드에서는 임의로 `var activity = GetCurrentActivityContext();`를 통해 지정했다.  
iOS에서는 Cancel타입을 사용하면 해당 버튼은 무조건 취소 기능을 제공한다. 그래서 Android에서는 *Neutral타입을 사용 && action을 넣지 않으면 취소* 기능을 제공하도록 구현했다.
```cs
public class CustomAlertManager : ICustomAlertManager
{
    public void Show(string title, string message, List<AlertButton> buttonList)
    {
        var activity = GetCurrentActivityContext();

        AlertDialog.Builder builder = new AlertDialog.Builder((Activity)activity);
        builder.SetTitle(title);
        builder.SetMessage(message);
        builder.SetCancelable(true);

        foreach (var button in buttonList)
        {
            switch (button.AndroidButtonType)
            {
                case AndroidButtonType.Positive:
                    if (button.Action != null)
                        builder.SetPositiveButton(button.Text, (senderAlert, args) => button.Action());
                    else if (button.ActionAsync != null)
                        builder.SetPositiveButton(button.Text, async (senderAlert, args) => await button.ActionAsync());
                    break;

                case AndroidButtonType.Neutral:
                    if (button.Action != null)
                        builder.SetNegativeButton(button.Text, (senderAlert, args) => button.Action());
                    else if (button.ActionAsync != null)
                        builder.SetNegativeButton(button.Text, async (senderAlert, args) => await button.ActionAsync());
                    else
                        builder.SetNegativeButton(button.Text, (senderAlert, args) => builder.Dispose());
                    break;

                case AndroidButtonType.Negative:
                    if (button.Action != null)
                        builder.SetNeutralButton(button.Text, (senderAlert, args) => button.Action());
                    else if (button.ActionAsync != null)
                        builder.SetNeutralButton(button.Text, async (senderAlert, args) => await button.ActionAsync());
                    break;

                default:
                    break;
            }
        }

        var customAlertDialog = builder.Create();
        customAlertDialog.Show();
    }
}
```

## iOS/Dependency: CustomAlertManager.cs
iOS에서는 action을 설정하는 부분을 분리할 수 있었다.  
iOS에서는 3버튼 이상의 선택지에 대해서는 `Alert`가 아닌 `ActionSheet` 사용을 권고하는듯 하다.
```cs
public class CustomAlertManager : ICustomAlertManager
{
    public void Show(string title, string message, List<AlertButton> buttonList)
    {
        var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

        foreach (var button in buttonList)
        {
            switch (button.iOSButtonType)
            {
                case iOSButtonType.Cancel:
                    alert.AddAction(UIAlertAction.Create(button.Text, UIAlertActionStyle.Cancel, null));
                    break;

                case iOSButtonType.Destructive:
                    AddAction(alert, button, UIAlertActionStyle.Destructive);
                    break;

                case iOSButtonType.Default:
                    AddAction(alert, button, UIAlertActionStyle.Default);
                    break;

                default:
                    break;
            }
        }

        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
    }

    private void AddAction(UIAlertController alert, AlertButton button, UIAlertActionStyle actionStyle)
    {
        if (button.Action != null)
        {
            alert.AddAction(UIAlertAction.Create(button.Text, actionStyle, action => button.Action() ));
        }
        else if (button.ActionAsync != null)
        {
            alert.AddAction(UIAlertAction.Create(button.Text, actionStyle, async action => await button.ActionAsync() ));
        }
    }
}
```
