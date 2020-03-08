# Variable

### let
- 변수

### const
- 상수, Read only (선언 후 내용 변경 불가)

### var
- 최근 권장하지 않는 방식.. 
- 아래와 같이 여러번 선언 가능
```js
var a = 1;
var a = 2;
```
- babel등의 도구 없이 구형 웹브라우저에서 let, const가 적용되지 않으므로 사용 필요

### String
```js
var str1 = 'hello'   //single quote 또는 double quote 무관
var str2 = "hello";  //semicolon 유무 무관
```

### NULL
- 없다
```js
let friend = null;      //친구가 없다
```

### Undefined
- 아직 정해지지 않았다
```js
let criminal;
console.log(criminal);  //undefined
```

<br />

> fastcampus frontend course 25-03