# DateTime

## 1. DateTime formatting in xaml
- xaml에서 `dateTime`의 포맷을 변경한다
- 바인딩한다  
- 포맷 형식 참고: https://www.csharp-examples.net/string-format-datetime/

**.xaml**
```xaml
<Label x:Name="FormattedTime"
       Text="{Binding myTime, StringFormat='{0:MM-dd HH:mm}'}"/>
```
**viewmodel.cs**
```csharp
public DateTime myTime => DateTime.Now
```
