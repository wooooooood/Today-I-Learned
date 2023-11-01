## 엑셀 파일을 다운로드할 때 사용하는 api 
- `PageModel` 에서는 `System.Net.Mime.MediaTypeNames.Application.Octet`를 썼는데 컨트롤러에서도 컴파일은 됨.. 확인은 안해봄
```cs
[HttpGet("test")]
public async Task<FileResult> Get()
{
    var contentRootPath = _hostingEnvironment.ContentRootPath;

    // "items" is a List<T> of DataObjects
    var items = await _mediator.Send(new GetExcelRequest());

    var fileInfo = new ExcelFileCreator(contentRootPath).Execute(items);
    var bytes = System.IO.File.ReadAllBytes(fileInfo.FullName);

    var fileContentResult = new FileContentResult(bytes, System.Net.Mime.MediaTypeNames.Application.Octet);

    return fileContentResult;
}
```
### 파일 이름을 서버에서 설정해서 전달
- `Content-Disposition` 에 파일 이름이 들어가는데, 이걸 expose header로 설정해야 한다

```cs
[HttpGet("test")]
public async Task<FileResult> Get()
{
    var contentRootPath = _hostingEnvironment.ContentRootPath;

    // "items" is a List<T> of DataObjects
    var items = await _mediator.Send(new GetExcelRequest());

    var fileInfo = new ExcelFileCreator(contentRootPath).Execute(items);
    var bytes = System.IO.File.ReadAllBytes(fileInfo.FullName);

    const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    HttpContext.Response.ContentType = contentType;
    HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

    var fileContentResult = new FileContentResult(bytes, contentType)
    {
        FileDownloadName = fileInfo.Name
    };

    return fileContentResult;
}
```

- 파일 이름이 한글이면 `charset=utf-8`을 설정해줘야 한다.
- `File` 객체도 `FileContentResult`라서 아래와 같이 쓸 수도 있다
```cs
Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet; charset=utf-8";
Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

return File(clone.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, "한글파일제목.xlsx");
            
```

### 단, 파일이름이 한글인 경우 브라우저에서 깨질 수 있음 -> 서버에서 인코딩 필요
- 웹으로 파일을 보내주는 경우에는 js에서 decode 하면 되는데 서버에서는 이렇게 한다  
```cs
FileDownloadName = System.Web.HttpUtility.UrlEncode("안녕 안녕.xlsx")
```
🧐TODO 근데 띄어쓰기가 `+`로 표시되는데 이건 어떻게 없애는지..

### ref
- https://stackoverflow.com/questions/38877195/how-to-return-an-excel-file-from-asp-net-core-web-api-web-app
- https://kjun.kr/1131