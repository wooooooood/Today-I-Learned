# Get first/last day of month
> https://stackoverflow.com/questions/13571700/get-first-and-last-date-of-current-month-with-javascript-or-jquery
```js
var today = new Date();
var firstDayOfMonth = new Date(today.getFullYear(), today.getMonth(), 1);
var lastDayOfMonth = new Date(today.getFullYear(), today.getMonth()+1, 0);
```
