### Url param에 따라 render여부 나타내기
```cshtml
@{
  if (Context.Request.Query["show"] != "true")
  {
    <p>Show!</p>
  }
}
```
