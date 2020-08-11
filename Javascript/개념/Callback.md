# Callback
: 특정 함수의 인자로 외부에 선언된 Callback함수를 전달, 해당 함수가 실행될 때 Callback 함수를 호출할 수 있다. 결국, 특정 함수의 실행이 끝나기를 기다릴 수 있게 된다!
> 참고 : https://developer.mozilla.org/en-US/docs/Glossary/Callback_function  

### 예제1
```javascript
function PracticeEnglish(callback){
    console.log("How are you?");

    callback();
}

function Response(){
    console.log("I'm fine and you?");
}

PracticeEnglish(Response);
```

<br />

### 참고하기 좋은 자료
- https://codeburst.io/javascript-what-the-heck-is-a-callback-aba4da2deced
