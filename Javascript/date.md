# Get last day of month
> https://stackoverflow.com/a/13773408
```js
var today = new Date();
var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth()+1, 0);
```
