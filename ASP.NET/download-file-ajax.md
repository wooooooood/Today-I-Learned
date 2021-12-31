### 파일로 다운로드 with `Ajax`, `ASP.NET`
https://stackoverflow.com/a/30704519/4894523

```cs
public ActionResult DownloadAttachment(int studentId)
{          
    // Find user by passed id
    // Student student = db.Students.FirstOrDefault(s => s.Id == studentId);

    var file = db.EmailAttachmentReceived.FirstOrDefault(x => x.LisaId == studentId);

    byte[] fileBytes = System.IO.File.ReadAllBytes(file.Filepath);

    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Filename);                       

}
```

```js
$("#DownloadAttachment").click(function () {
  $.ajax(
  {
    url: '@Url.Action("DownloadAttachment", "PostDetail")',
    contentType: 'application/json; charset=utf-8',
    datatype: 'json',
    data: {
      studentId: 123
    },
    type: "GET",
    success: function () {
        window.location = '@Url.Action("DownloadAttachment", "PostDetail", new { studentId = 123 })';
    }
  });
});
```

핵심은 여기다.  
`Url.Action(action, controller)`이고 내 경우는  
`url: "@Url.Content("~")/FOLDER/PAGE?handler=MYHANDLER"`  
`success: function(){ "@Url.Content("~")/FOLDER/PAGE?handler=MYHANDLER";}`  
라고 작성하니 파일이 알아서 다운로드 폴더에 들어갔다.
```js
success: function () {
  window.location = '@Url.Action("DownloadAttachment", "PostDetail")';
}
```
