### Url param에 따라 render여부 나타내기
```cshtml
@{
  if (Context.Request.Query["show"] != "true")
  {
    <p>Show!</p>
  }
}
```

### Javascript에서 `.cshtml.cs` 의 property 사용하기
이렇게 하면 object로 list에 들어간다
```js
const list = @Html.Raw(Json.Serialize(@Model.MyList));
```
