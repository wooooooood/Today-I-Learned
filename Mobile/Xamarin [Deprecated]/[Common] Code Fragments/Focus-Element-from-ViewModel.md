## How to Focus Element from ViewModel

**Solution 1.** use `Triggers`  
https://stackoverflow.com/a/32215477
사용 안해봄  
  
**Solution 2.** use `Command Parameter`  
https://stackoverflow.com/a/46055711
```xml
<ToolbarItem
    Icon="Calendar"
    Command="{Binding ShowCalendarCommand}"
    CommandParameter="{x:Reference Datepicker}" />
```
```cs
#region toolbar commands
public ICommand ShowCalendarCommand => new RelayCommand<Object>(ShowCalendar);
#endregion

private void ShowCalendar(Object obj)
{
    var calendar = (DatePicker)obj;
    calendar.Focus();
}
```
