# Enum Parse
## String 값을 Enum으로
https://docs.microsoft.com/ko-kr/dotnet/api/system.enum.parse?view=net-5.0

- 이렇게 하는 경우 colorValue의 type은 그냥 `object`이다. `(int)colorValue` 처럼 type cast하려고 하면 Exception이 발생한다.
```cs
var colorValue = Enum.Parse(typeof(Colors), colorString, true);
```

- 아래와 같이 해야 colorValue의 type이 `Enum` Colors가 된다.
```cs
var colorValue = (Colors)Enum.Parse(typeof(Colors), colorString, true);
```

### Enum Description
```cs
public enum 
{
  [Description("Dark Orange is like carrot with dirt")]
  DarkOrange,
  [Description("Sunkissed Orange Color!")]
  Orange,
  [Description("Light Orange feels warm")]
  LightOrange,
}
```

- `Refelection`을 사용함
```cs
public static class EnumHelper 
{
  public static string GetEnumDescription(this Enum value)
  {
    FieldInfo fileInfo = value.GetType().GetField(value.ToString());
    DescriptionAttribute[] attributes = (DescriptionAttribute[])fileInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

    if (attributes != null && attributes.Length > 0)
      return attributes[0].Description;
    else
      return value.ToString();
  }
}
```
