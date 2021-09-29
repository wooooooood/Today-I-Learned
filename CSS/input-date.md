# input type="date" value 없애기
- https://baegofda.tistory.com/106
- 모양이 유지된다
- 오른쪽 달력 아이콘을 눌러야 date를 선택할 수 있다.
- 단, value를 사용하는 경우 selected value까지 안보여서 다른 작업을 해줘야한다: https://stackoverflow.com/questions/28686288/remove-default-text-placeholder-present-in-html5-input-element-of-type-date 
```css
input[type=date]::-webkit-datetime-edit-text {
  -webkit-appearance: none;
  display: none;
}
input[type=date]::-webkit-datetime-edit-month-field {
  -webkit-appearance: none;
  display: none;
}
input[type=date]::-webkit-datetime-edit-day-field {
  -webkit-appearance: none;
  display: none;
}
input[type=date]::-webkit-datetime-edit-year-field {
  -webkit-appearance: none;
  display: none;
}

//shorten
::-webkit-datetime-edit-text,
::-webkit-datetime-edit-month-field,
::-webkit-datetime-edit-day-field,
::-webkit-datetime-edit-year-field {
  display: none;
}
```

# input type="date" value color
- 이 경우 클릭하면 보여진다..
- 구글링하여 `user-select: none;`을 추가해봤지만 원하는 모양은 아니었다
```css
input[type=date] {
  color: transparent;
}
```
![image](https://user-images.githubusercontent.com/40855076/135221235-569be202-7e5c-4fd9-9e60-5eeceb7a9080.png)

# input type="date" value format
- https://stackoverflow.com/a/31162426/4894523: Chrome, Edge에서 동작한다.
1. 맨 위의 [input type="date" value 없애기](https://github.com/wooooooood/Today-I-Learned/new/master/CSS#input-typedate-value-%EC%97%86%EC%95%A0%EA%B8%B0) 를 수행한다.
2.
- html
```html
<input type="date" data-date="" value="Date"/>
```
- css
```css
input[type=date] {
  position: relative;
}

input[type=date]:before {
  position: absolute;
  left: 3px;
  content: attr(data-date);
  display: inline-block;
  color: black;
}
```
- js
```js
const onInputChange = ({ target }) => {
  target.setAttribute("data-date", moment(target.value).format("YYYY.M.D"));
};
```
