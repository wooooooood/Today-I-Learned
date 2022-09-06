```js
const now = moment();
```

- 아래 두 가지는 같다
```js
now.add(-1, "month");
now.subtract(1, "month");
```

- Difference between two date
```js
endDate.diff(startDate, "months");

# 음수 값을 반환
startDate.diff(endDate, "months");
```
