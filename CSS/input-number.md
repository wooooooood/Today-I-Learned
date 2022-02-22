input type number 하면 input창 안에 위아래 화살표가 생기고, input 내부에서 스크롤 시 방향에 따라 숫자가 오르내린다.  
이 두 가지를 모두 없애기 위한 방법 중 하나..

```css
input[type="number"] {
  -moz-appearance: textfield; //firefox
}
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
}
```

```jsx
const onWheel = ({ target }) => {
  target.blur();
};
```
