# CORS 설정
ASP.NET Core5 해결방법 중 하나: Enable CORS with Attributes


- 각 api별로 CORS를 설정할 수 있다
```cs
[Route("api/[controller]")]
[ApiController]
public class WidgetController : ControllerBase
{
    // GET api/values
    [EnableCors("AnotherPolicy")]
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "green widget", "red widget" };
    }

    // GET api/values/5
    [EnableCors("Policy1")]
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return id switch
        {
            1 => "green widget",
            2 => "red widget",
            _ => NotFound(),
        };
    }
}
```
- 사용하는 CORS 허용 방법에 따라, `UseCors()`를 선언하는 위치가 중요하다
```cs
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Policy1",
                builder =>
                {
                    builder.WithOrigins("http://example.com",
                                        "http://www.contoso.com");
                });

            options.AddPolicy("AnotherPolicy",
                builder =>
                {
                    builder.WithOrigins("http://www.contoso.com")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
```

- https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0#attr


# ⚠ 주의!!! multiple CORS
- 두 개 이상의 CORS를 설정한다면, 선언 순서에 영향을 받는다. request가 들어왔을 때 첫 policy에서 매칭이 된다면 그 policy를 사용하게 된다!! 
```cs
app.UseCors("CORS1");
app.UseCors("CORS2");
```
