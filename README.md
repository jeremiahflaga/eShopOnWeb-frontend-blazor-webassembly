# eShopOnWeb-Frontend-Blazor-WebAssembly-PWA

A sample frontend project for eShopOnWeb (https://github.com/dotnet-architecture/eShopOnWeb) using Blazor WebAssembly PWA


Be sure to `AllowAnyOrigin()` in CORS in the backend API

``` csharp
services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
                      builder =>
                      {
                          //builder.WithOrigins(baseUrlConfig.WebBase.Replace("host.docker.internal", "localhost").TrimEnd('/'));
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();
                          builder.AllowAnyHeader();
                      });
});
```

... or else you will encounter the `Children could not be evaluated` error.


## References:

- [Blazor WebAssembly - JWT Authentication Example & Tutorial](https://jasonwatmore.com/post/2020/08/13/blazor-webassembly-jwt-authentication-example-tutorial) by Jason Watmore

