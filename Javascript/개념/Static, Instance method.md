# Static vs Instance

```js
const v = new PVector(0,0);
const u = new PVector(4,5);
```

**Static method**
- 정적 함수는 객체 자체를 변경하지 않는다 (return값이 있다)
```js
const result = PVector.add(v, u);
```

**Instance method**
- 객체가 변경된다
```js
v.add(u);
```

### Reference
- https://ko.khanacademy.org/computing/computer-programming/programming-natural-simulations/programming-vectors/a/static-functions-vs-instance-methods
