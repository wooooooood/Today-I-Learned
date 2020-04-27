# Truthy, Falsy

```js
function print(person) {
    if (person === undefined || person === null) {
        return;
    }
    console.log(person.name);
}

//same with
function print(person) {
    if (!person) {
        return;
    }
    console.log(person.name);
}
```

- **Truthy**: falsy하지 않은 값
- **Falsy**: undefined, null, 0, '', NaN
    - 아래 값들은 모두 falsy한 값이다
    - 아래 결과는 모두 true로 출력된다
```js
console.log(!undefined); 
console.log(!null);      
console.log(!0);         
console.log(!'');        
console.log(!NaN);       
//NaN: not a number (ex const value = 1/'asdf')
```

```js
const value = {a:1};
const truthy = value? true : false;
//위 줄은 아래와 같다.
const simplerTruthy = !!value;
```

> fastcampus frontend 26-2
