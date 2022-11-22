### ajax post 했는데 400 오류뜰때
1. put this on top at `.cshtml` file  

razor: 
```
@{
  @Html.AntiForgeryToken()
}
```

js:
```js
$.ajax({
  type: "POST",
  url: "@Url.Content("~")/Path/Page?handler=Cancel",
  data: JSON.stringify({ param1, param2 }),
  contentType: "application/json; charset=utf-8",
  beforeSend: function (xhr) {
      xhr.setRequestHeader("RequestVerificationToken",
          $('input:hidden[name="__RequestVerificationToken"]').val());
  },
  success: function (result) {
      //do sth successful
  },
  error: function (err) {
      alert('err!');
  },
  complete: function () {
      //like finally
  }
});
```
2. `.cs` file
```cs
public async Task<IActionResult> OnPostCancel([FromBody] Parameter parameter)
{
    return new JsonResult(true);
}
```

### ajax post
> 되던 방식을 복붙한거같은데 계속 400 에러가 떠서 추가. 레이저는 정말..😈
- ref: https://www.learnrazorpages.com/razor-pages/ajax/form-post#using-jquery
```html
<form method="post">
    <input type="text" class="input__group--input" asp-for="@Model.Name" required>
    <input type="text" class="input__group--input" asp-for="@Model.Email" required>
</form>
```

```js
$.post("@Url.Content("~")/Account/Signup?handler=Test", $('form').serialize(), function () {
    alert('Posted using jQuery');
});
```
- js에서 serialize 방식이 다른거같긴하다. 어쩐지 Post인데 FromBody를 안해도되나..?
```
console.log($('form').serialize())
Name=name&Email=email

console.log(JSON.stringify({ Name: "name" }))
{"Name":"name", "Email":"email"}
```

```cs
public class Test
{
    public string Name { get; set; }
    public string Email { get; set; }
}

 public async Task<IActionResult> OnPostTest(Test test)
{
    return Page();
}
```