### `input`을 누르면 값이 모두 select되도록
- https://stackoverflow.com/a/40261505/4894523
- (render method로 arrow function 지양해야 한다고 댓글에 있긴한데,) arrow function 형태로 작성하면 동작 안한다 (!)
```
const handleFocus = (event) => event.target.select();
const Input = (props) => <input type="text" value="Some something" onFocus={handleFocus} />
```
