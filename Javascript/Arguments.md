
# Arguments 
**가변인자**  
: 함수 Arguments의 타입, 개수가 상관없다!  

<br />

### 1. Arguments 개수 구하기  

```javascript
function GetArgsLength() {
    console.log(arguments.length);
}

GetArgsLength();          //0   
GetArgsLength(1);         //1
GetArgsLength(1, "2");    //2
```

<br />

### 2. Arguments 타입 구하기

```javascript
function GetArgsType() {
    for (index in arguments) {
        console.log(typeof arguments[index]);
    }
}

GetArgsType();           //
GetArgsType(1, "2");     // number, string
GetArgsType(undefined);  // undefined
GetArgsType([1, 2, 3]);  // object
```

<br />

### 3. 응용  
- https://www.freecodecamp.org/learn/javascript-algorithms-and-data-structures/intermediate-algorithm-scripting/arguments-optional