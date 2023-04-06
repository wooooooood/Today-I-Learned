## 현상
- `form`이 있는 페이지에서 refresh 하면 `form`이 다시 제출(resubmit) 되는 현상

## 해결방법 - [PRG pattern](https://en.wikipedia.org/wiki/Post/Redirect/Get)
![PRG 패턴 사용](https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/PostRedirectGet_DoubleSubmitSolution.png/350px-PostRedirectGet_DoubleSubmitSolution.png)

- https://exceptionnotfound.net/implementing-post-redirect-get-in-asp-net-core-razor-pages/
  - `Post()` -> `RedirectToPage()` -> `Get()`

## Troubleshoot: `RedirectToPage("/")` causes error "No page named '/' matches the supplied values"
- https://stackoverflow.com/a/62461102
  > expects the parameter to refer to a cshtml page in your project
- 그러니 내 `cshtml.cs` 파일의 이름을 적어줘야 한다
  - ex. Url은 "example.com/Account/Signin" 이어도 해당 페이지 이름이 Login.cshtml.cs 이면 `"./Login"`