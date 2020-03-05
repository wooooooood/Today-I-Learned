# DateTime

### Format
> https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
```cs
DateTime.Now.ToString("MM/dd/yyyy");
```
<br />

### Convert: String -> DateTime
> https://www.techiedelight.com/convert-string-to-datetime-csharp/
```cs
var result = DateTime.Parse(targetString);
DateTime.TryParse(targetString, out result);
```
