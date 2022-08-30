razor page에서 드롭다운 리스트를 이렇게 작성할 수 있다.
```cshtml
<select name="country" id="country" class="select-dropdown" 
  asp-items="@Model.Countries" 
  asp-for="@Model.SelectedCountryId" 
  onchange="this.form.submit()"></select>
```

```cs
public SelectList Countries { get; set; }
[BindProperty]
public int? SelectedCountryId { get; set; }
```

이때 함정은 `Countries`에는 `[BindProperty]`를 붙이지 않는다는 것이다.
붙여도 동작은 하는데 ajax post를 하려고 하니 아래와 같은 오류가 났다. 단순히 오류만 보고 parameter를 받는 constructor에서 null만 아니도록 설정을 해줬는데도 안되었다.
[이 글](https://github.com/dotnet/AspNetCore.Docs/issues/11345)을 보고 `Countries`의 `[BindProperty]`를 제거하니 동작했다.
왜 ajax post 할때 이게 발견되었는지는.. 🧐
```
"System.InvalidOperationException: Could not create an instance of type 'Microsoft.AspNetCore.Mvc.Rendering.SelectList'. Model bound complex types must not be abstract or value types and must have a parameterless constructor. Record types must have a single primary constructor. Alternatively, set the 'Countries' property to a non-null value in the 'Pages.PageModel' constructor.
   at Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexObjectModelBinder.CreateModel(ModelBindingContext bindingContext)
   at Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexObjectModelBinder.BindModelCoreAsync(ModelBindingContext bindingContext, Int32 propertyData)
   at Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder.BindModelAsync(ActionContext actionContext, IModelBinder modelBinder, IValueProvider valueProvider, ParameterDescriptor parameter, ModelMetadata metadata, Object value, Object container)
   at Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.PageBinderFactory.<>c__DisplayClass2_0.<<CreatePropertyBinder>g__Bind|0>d.MoveNext()
```

