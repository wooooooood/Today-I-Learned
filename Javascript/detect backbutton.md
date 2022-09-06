# detect backbutton
=> `popstate` event를 사용
```js
window.addEventListener("popstate", () => console.log("backbutton clicked!"), false);
```

## Troubleshoot1. `popstate` event 삭제가 안됨?
=> 참조한 함수를 제거하도록 수정해야함
```js
//👎 이 경우 콜백 함수 두 가지는 다른 것으로 판단된다
window.addEventListener("popstate", () => console.log("do sth"), false);
window.removeEventListener("popstate", () => console.log("do sth"), false);

//👍 함수를 정의해서 호출하자
window.addEventListener("popstate", onBackbutton, false);
window.removeEventListener("popstate", onBackbutton, false);
const onBackbutton = () => {
    //do sth..
}
```

=> 뭔가 수행 후 이벤트를 바로 제거할 수도 있다
```js
window.addEventListener("popstate", onBackbutton, false);
const onBackbutton = () => {
    //do sth..
    window.removeEventListener("popstate", onBackbutton , false);
}
```