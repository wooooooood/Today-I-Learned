- [IP](https://www.oreilly.com/library/view/regular-expressions-cookbook/9780596802837/ch07s16.html)
```
(?:[0-9]{1,3}\.){3}[0-9]{1,3}
```

- [Date](https://stackoverflow.com/questions/11500330/regular-expression-for-date-format)
```
(?<WeekDay>\w+)\s+(?<Month>\w+)\s+(?<MonthDay>\d+)\s+(?<Hour>\d+):(?<Min>\d+):(?<Sec>\d+)\s+(?<TimeZone>\w+)\s+(?<Year>\d+)
```

- 영문 대소문자/특수문자/숫자 포함 8자리 이상 (비밀번호)
```
/^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*+-=~_])(?=.*[0-9]).{8,}$/
```
