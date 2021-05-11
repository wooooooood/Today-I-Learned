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

### Get Enum Description
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
