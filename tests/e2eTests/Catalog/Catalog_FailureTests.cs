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
	public class Catalog_FailureTests : TestContext
    {
        Mock<ILocalStorageService> localStorageMock = new Mock<ILocalStorageService>();

        public Catalog_FailureTests()
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

        [Fact]
        public void ShouldShowLoading()
        {
            // Arrange
            var sut = this.RenderComponent<CatalogItems>();

            // Act
            var elem = sut.Find("[data-test='loading']");

            // Assert
            Assert.NotNull(elem);
        }
    }
}
