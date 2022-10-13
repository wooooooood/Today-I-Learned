### 100vh설정한 화면이 모바일 브라우저의 위/아래 bar로 인해 스크롤이 잡힐때
> ref: https://blog.leehov.in/39
```js
funciton setScreenSize() {
  let vh = window.innerHeight * 0.01;

  document.documentElement.style.setProperty('--vh', `${vh}px`);
}

setScreenSize();
```
```css
height: calc(var(--vh, 1vh) * 100);
```
