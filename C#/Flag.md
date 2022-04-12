Ref: https://andromedarabbit.net/csharp_flag_operations/

```cs
[Flags]
public enum Column
{
  Primary = 1,
  Secondary = 2,
  Tint = 4,
  Disabled = 8
}
```

이런 게 된다!
```cs
//multi 값
Column MyColumns = Column.Customer | Column.Contract;

//값이 있는지 확인
if((MyColumns & Column.Customer) != 0)

//특정 값 넣기
MyColumns |= Column.Tech;

//특정 값 제거
MyColumns &= ~Column.Tech;
```
