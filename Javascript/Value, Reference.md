
# Javascript에서 값 할당할 때  
**Passed by Value**  
: Boolean, Null, Undefined, String, Number, Symbol     <- Primitive types

    var variable = 1;
    var copy = variable;
    
    variable = 0;
    
    console.log(variable); // 0
    console.log(copy);     // 1

<br />

**Passed by Reference**  
: Array, Function, Object

    var array = [1,2,3];
    var ref = array; //값을 복사하는 것이 아니라 참조
    
    array[0] = 0;
    
    console.log(array); // [0,2,3]
    console.log(ref);  // [0,2,3]
  
<br />
<br />

# 참조 없는 복사를 하고 싶다면?
### 1. Json을 사용하여 직렬화 후 파싱

    var array = [1,2,3];
    var copy = JSON.parse(JSON.stringify( array ));
    
    array[0] = 0;
    
    console.log(array); // [0,2,3]
    console.log(copy);  // [1,2,3]

> 참고 : https://programmingsummaries.tistory.com/143
  
<br />

### 2. 값을 하나하나 대입

    var array = [1,2,3];
    var copy = [];
    
    array.forEach(element => {
      copy.push(element);
    });
    
    array[0] = 0;
    
    console.log(array); // [0,2,3]
    console.log(copy);  // [1,2,3]
  
<br />

### 3. ES6 방법 (->IE 지원안됨)

    var array = [1,2,3];
    var copy = [...array];
    
    array[0] = 0;
    
    console.log(array); // [0,2,3]
    console.log(copy);  // [1,2,3]

> 참고 : https://www.samanthaming.com/tidbits/35-es6-way-to-clone-an-array
  
<br />

### 4. Slice 사용

    var array = [1,2,3];
    var copy = array.slice();
    
    array[0] = 0;
    
    console.log(array); // [0,2,3]
    console.log(copy);  // [1,2,3]
