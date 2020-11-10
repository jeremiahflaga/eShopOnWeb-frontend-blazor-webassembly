//using AngleSharp.Text;
//using BlazorWebAssemblyApp.Models;
//using BlazorWebAssemblyApp.Pages;
//using BlazorWebAssemblyApp.Services;
//using Bunit;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Xunit;

//namespace e2eTests.Catalog
//{
//    public class Catalog_SuccessTests : TestContext
//    {
//        Mock<ILocalStorageService> localStorageMock = new Mock<ILocalStorageService>();

//        public Catalog_SuccessTests()
//        {
//            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
//            IConfiguration configuration = configBuilder.Build();
            
//			this.Services
//                .AddScoped<IConfiguration>(x => configuration)
//                //.AddScoped<IAuthenticationService, AuthenticationService>()
//                //.AddScoped<IUserService, UserService>()
//                .AddScoped<IHttpService, HttpService>()
//				.AddScoped<ILocalStorageService>(x => localStorageMock.Object)
//				.AddScoped<ICatalogService, CatalogService>();

//            // configure http client
//            this.Services.AddScoped(x => {
//                var apiUrl = new Uri(configuration["apiUrl"]);

//                return new HttpClient() { BaseAddress = apiUrl };
//            });

//        }

//        [Fact]
//        public void shows_catalog_items()
//        {
//            var sut = this.RenderComponent<CatalogItems>();
//            var elem = sut.Find("[data-test='catalog-items']");
//            Assert.NotNull(elem);
//        }

//        [Fact]
//        public void shows_pagination()
//        {
//            var sut = this.RenderComponent<CatalogItems>();
//            var elem = sut.Find("[data-test='pagination']");
//            Assert.NotNull(elem);
//        }

//        //[Fact]
//        //public void shows_correct_number_of_catalog_items_on_first_page()
//        //{
//        //    var pageSize = 5;
//        //    catalogServiceMock.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), It.IsAny<int>()))
//        //            .Returns(Task.FromResult(new ListPagedCatalogItemResponse()
//        //            {
//        //                CatalogItems = generateCatalogItems(pageSize).ToList(),
//        //                PageCount = It.IsAny<int>()
//        //            }));

//        //    var sut = this.RenderComponent<CatalogItems>();
//        //    var elems = sut.FindAll("[data-test='catalog-item']");

//        //    Assert.Equal(pageSize, elems.Count);
//        //}

//        private IEnumerable<CatalogItem> generateCatalogItems(int count)
//        {
//            for (int i = 0; i < count; i++)
//                yield return new CatalogItem
//                {
//                    Id = i,
//                    Name = Faker.Lorem.Words(3).ToString(),
//                    Description = Faker.Lorem.Sentence(10),
//                };
//        }

//    }
//}
