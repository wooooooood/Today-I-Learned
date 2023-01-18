## 1. Switch user toggled event only

### Discussion
현재 Xamarin에서는 user action에 의한 토글이 아니라 Programatically 설정/ 바인딩만 해도 토글 이벤트가 발생한다.  
아래와 같은 경우에는 무한 토글이 일어난다.
```csharp
public void AlarmSwitchToggledByUser(sender s, EventArgs args)
{
    AlarmSwitch.IsToggled = !AlarmSwitch.IsToggled;
}
```
[Xamarin Forms Issue - Enhancement suggestion](https://github.com/xamarin/Xamarin.Forms/issues/8416) 에서도 알 수 있듯이 많은 사람들이 유저토글과 바인딩토글이 분리되어야 한다고 생각함.. 아직 개발중이진 않은듯  

### 목적  
- User action에 의한 토글 이벤트만 발생시킨다
- Programatical value change에서는 토글 이벤트가 발생하지 않는다

### Workaround
1. [시도해 보았으나 실패했다](https://www.bettereducation.com.au/forum/it.aspx?g=posts&t=7822)

2. 마음에 안들지만 나는 주로 이 방법을 쓴다.. 

**.xaml**  
- 이벤트 바인딩
```xml
<Switch x:Name="AlarmSwitch"
Toggled="AlarmSwitchToggledByUser"/>
```

**.xaml.cs**  
- programatically 수정하기 전후로 토글 이벤트를 빼고 넣기. 그나마 직관적이라고 생각된다.
```csharp
AlarmSwitch.Toggled -= AlarmSwitchToggledByUser;
AlarmSwitch.IsToggled = NotificationHelper.IsEnable;
AlarmSwitch.Toggled += AlarmSwitchToggledByUser;
```