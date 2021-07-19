### Generic을 이용하여 string값을 올바른 타입의 변수로 변경하기
**default:**
```cs
default(T);
```

**enum인 경우:**
```cs
(T)Enum.Parse(typeof(T), inputValue);
```

**return T 이지만 nullable한 T일때:**
```cs
var t = typeof(T);
if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
{
    t = Nullable.GetUnderlyingType(t);
    return (T)Convert.ChangeType(inputValue, t);
}
```

**합체:** `GetValue<float?>(someStringValue)`
```cs
private T GetValue<T>(string inputValue)
{
    if (inputValue == "")
        return default(T);

    if (typeof(T).IsEnum)
        return (T)Enum.Parse(typeof(T), inputValue);

    var t = typeof(T);
    if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
    {
        t = Nullable.GetUnderlyingType(t);
        return (T)Convert.ChangeType(inputValue, t);
    }

    return (T)Convert.ChangeType(inputValue, typeof(T));
}
```
