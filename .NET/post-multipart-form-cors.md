# Post Multipart - ASP.NET side
CORS 설정을 AllowAnyOrigin.AllowAnyMethod.AllowAnyHeader 로 했고 동일한 controller 내의 다른 api들은 잘되는데 당황스럽게도 `"Content-Type": "multipart/form-data"` 헤더를 가진 api 요청을 날릴때만 CORS 오류를 콘솔에 찍어내는 상황을 마주했다.

파일 크기 설정 등등 몇가지를 따라해보다가 [내게 해당하는 방법](https://stackoverflow.com/a/61427090/4894523)을 찾아냈다.  
(보다보니 닷넷뿐만아니라 Spring?쪽에서도 Consume 어쩌구 하는 attribute를 쓰는거같다. 다 핵심은 비슷한듯..)  

```cs
[HttpPost]
[Consumes("multipart/form-data")]  // 여기!!
public bool Post([FromForm] myObj docs)
{
    return true;
}

public class myObj
{
    public string description { get; set; }
    public IFormFile imageFile { get; set; }
}
```
<br />
<br />

# 덤으로 axios로 form 보낼때 - client side
`🧨특이점`: FormData는 console.log안됨. 해봤자 아무리 append해도 빈 FormData가 나옴
```js
let myObj = new FormData();
myObj.append("description", "TESTTTT");
myObj.append("imageFile", target.files[0]);

await axios.post(path, myObj, {
  headers: {
    "Content-Type": "multipart/form-data",
  },
});
```

<br />
<br />

### 만약 `List<IFormFile>`을 보낸다면

```cs
public class myObj
{
    public List<IFormFile> Images { get; set; }
}
```
- 같은 key에 계속 append한다
```js
let myObj = new FormData();
imageList.forEach((img) => {
  docs.append(`images`, img);
});
```

<br />
<br />

### 보낼때 타입 주의
- `nullable`인 값을 보낼 때 값이 만약 `null`이라면 `""` 으로 보내야 400오류 안남
```js
myObj.append("something", sth === null ? "" : sth);
```
- DateTime을 보내면 IOSString으로 꼭 바꿔줘라
```js
myObj.append("someDateTime", new Date().toISOString());
```