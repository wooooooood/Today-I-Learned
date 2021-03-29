# String 값을 Enum으로
https://docs.microsoft.com/ko-kr/dotnet/api/system.enum.parse?view=net-5.0

- 이렇게 하는 경우 colorValue의 type은 그냥 `object`이다. `(int)colorValue` 처럼 type cast하려고 하면 Exception이 발생한다.
```cs
var colorValue = Enum.Parse(typeof(Colors), colorString, true);
```

- 아래와 같이 해야 colorValue의 type이 `Enum` Colors가 된다.
```cs
var colorValue = (Colors)Enum.Parse(typeof(Colors), colorString, true);
```
