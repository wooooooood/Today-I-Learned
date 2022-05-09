# excel 파일을 업로드해서 내용을 읽는다

### .cshtml

```html
<input type="file" accept=".xls, .xlsx" />
```

### .cshtml.cs

```cs
public void Import(IFormFile FormFile)
{
  if (FormFile == null || FormFile.Length == 0)
    //err

  var stream = FormFile.OpenReadStream();
  IExcelDataReader reader = null;
  System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

  if (FormFile.FileName.EndsWith(".xls"))
    reader = ExcelReaderFactory.CreateBinaryReader(stream);
  else if (FormFile.FileName.EndsWith(".xlsx"))
    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
  else
    //not supported

  var result = reader.AsDataSet();
  foreach (DataTable Table in result.Tables)
  {
    for (int i = 0; i < Table.Rows.Count; i++)
    {
      for (int j = 0; j < Table.Columns.Count; j++)
      {
        //do sth with Table.Rows[i][j]
      }
    }
  }

  reader.Close();
}
```
