using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorWebAssemblyApp.Services;
using BlazorWebAssemblyApp.Helpers;

namespace BlazorWebAssemblyApp
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services
				.AddScoped<IAuthenticationService, AuthenticationService>()
				.AddScoped<IUserService, UserService>()
				.AddScoped<IHttpService, HttpService>()
				.AddScoped<ILocalStorageService, LocalStorageService>()
				.AddScoped<ICatalogService, CatalogService>();

			// configure http client
			builder.Services.AddScoped(x => {
				var apiUrl = new Uri(builder.Configuration["apiUrl"]);

				// use fake backend if "fakeBackend" is "true" in appsettings.json
				if (builder.Configuration["fakeBackend"] == "true")
					return new HttpClient(new FakeBackendHandler()) { BaseAddress = apiUrl };

				return new HttpClient() { BaseAddress = apiUrl };
			});

			var host = builder.Build();

			var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
			await authenticationService.Initialize();

			await host.RunAsync();
		}
	}
}
