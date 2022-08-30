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

### Use boolean value to JS variable
https://stackoverflow.com/questions/14448604/using-razor-how-do-i-render-a-boolean-to-a-javascript-variable
- 만약 이렇게 하면 browser의 source창에 `const isMobile = False`로 나타난다. 할당되는 타입이 boolean도 아니고 string도 아닌 형태라 오류가 난다.
```cshtml
const isMobile = @Request.Headers["User-Agent"].ToString().Contains("Mobile");

#Error
#Uncaught ReferenceError: False is not defined
```

- 해결:
```cshtml
const isMobile = @(Request.Headers["User-Agent"].ToString().Contains("Mobile") ? "true" : "false");
```

### Dropdown Select
- `asp-for`를 지정해서 Model property와 바인딩한다

```cshtml
<select asp-for="Type" asp-items="@(new SelectList(Model.Types))"></select>
```
