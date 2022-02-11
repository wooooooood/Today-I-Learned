### ajax post 했는데 400 오류뜰떄
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
