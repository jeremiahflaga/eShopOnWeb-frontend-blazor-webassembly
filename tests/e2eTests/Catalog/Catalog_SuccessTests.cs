using AngleSharp.Text;
using BlazorWebAssemblyApp.Models;
using BlazorWebAssemblyApp.Pages;
using BlazorWebAssemblyApp.Services;
using Bunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace e2eTests.Catalog
{
    public class Catalog_SuccessTests : TestContext
    {
        Mock<ILocalStorageService> localStorageMock = new Mock<ILocalStorageService>();

        public Catalog_SuccessTests()
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = configBuilder.Build();
            
			this.Services
                .AddScoped<IConfiguration>(x => configuration)
                //.AddScoped<IAuthenticationService, AuthenticationService>()
                //.AddScoped<IUserService, UserService>()
                .AddScoped<IHttpService, HttpService>()
				.AddScoped<ILocalStorageService>(x => localStorageMock.Object)
				.AddScoped<ICatalogService, CatalogService>();

            // configure http client
            this.Services.AddScoped(x => {
                var apiUrl = new Uri(configuration["apiUrl"]);

                return new HttpClient() { BaseAddress = apiUrl };
            });

        }

        // NOTE_JBOY: Compare these tests with that from e2eTests.Selenium project.
        // These tests will fail because you will need to have a mechanism for
        // waiting for the data to be displayed before you eecute the assert part
        // of the tests. Selenium has those .Wait() methods, but BUnit does not.
        // ... Oh I found a WaitForAssertion for BUnit: https://github.com/egil/bunit/issues/122
        // but it does not work, or I do not yet know how to make it work
        //[Fact]
        //public void shows_catalog_items()
        //{
        //    var sut = this.RenderComponent<CatalogItems>();
        //    sut.WaitForState(() => sut.Find("[data-test='catalog-items']") != null, TimeSpan.FromSeconds(5));
        //    var elem = sut.Find("[data-test='catalog-items']");
        //    sut.WaitForAssertion(() => Assert.NotNull(sut.Find("[data-test='catalog-items']")));
        //}

        //[Fact]
        //public void shows_pagination()
        //{
        //    var sut = this.RenderComponent<CatalogItems>();
        //    var elem = sut.Find("[data-test='pagination']");
        //    Assert.NotNull(elem);
        //}
    }
}
