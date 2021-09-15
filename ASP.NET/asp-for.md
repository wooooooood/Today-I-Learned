### Dropdown Select
- `asp-for`를 지정해서 Model property와 바인딩한다

```cshtml
<select asp-for="Type" asp-items="@(new SelectList(Model.Types))"></select>
```
