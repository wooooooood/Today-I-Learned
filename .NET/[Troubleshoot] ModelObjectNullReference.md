### Case. 
- ASP.NET 2.2
- Razor page 생성 후 Model의 property 사용하려 할 때 `NullReferenceException` 발생
- [참고](https://stackoverflow.com/questions/50023096/why-is-my-model-object-always-null-on-my-razor-page-in-dotnet-core-2-x-razor-pag)

### Solve.
변경 전
```cshtml
@page
@model IndexModel
<div>Hello @Model.UserName</div>
```
변경 후 (@page 삭제)
```cshtml
@model IndexModel
<div>Hello @Model.UserName</div>
```

### Cause.
- [@page Docs](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-3.0&tabs=visual-studio)
> @page makes the file into an MVC action - which means that it handles requests directly, without going through a controller.
