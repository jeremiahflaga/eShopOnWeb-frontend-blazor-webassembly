using AngleSharp;
using AngleSharp.Text;
using BlazorWebAssemblyApp.Models;
using BlazorWebAssemblyApp.Pages;
using BlazorWebAssemblyApp.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Catalog
{
    public class Catalog_SuccessTests : TestContext
    {
        Mock<ICatalogService> catalogServiceMock = new Mock<ICatalogService>();
        public Catalog_SuccessTests()
        {
            catalogServiceMock.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(Task.FromResult(new BlazorWebAssemblyApp.Models.ListPagedCatalogItemResponse()));

            this.Services.AddScoped(x => new Mock<Microsoft.Extensions.Configuration.IConfiguration>().Object);
            this.Services.AddScoped(x => catalogServiceMock.Object);
        }

        [Fact]
        public void shows_catalog_items()
        {
            var sut = this.RenderComponent<CatalogItems>();
            var elem = sut.Find("[data-test='catalog-items']");
            Assert.NotNull(elem);
        }

        [Fact]
        public void shows_pagination()
        {
            var sut = this.RenderComponent<CatalogItems>();
            var elem = sut.Find("[data-test='pagination']");
            Assert.NotNull(elem);
        }

        [Fact]
        public void shows_correct_number_of_catalog_items_on_first_page()
        {
            var pageSize = 7;
            catalogServiceMock.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(Task.FromResult(new ListPagedCatalogItemResponse()
                    {
                        CatalogItems = generateCatalogItems(pageSize).ToList(),
                        PageCount = It.IsAny<int>()
                    }));

            var sut = this.RenderComponent<CatalogItems>();
            var elems = sut.FindAll("[data-test='catalog-item']");

            Assert.Equal(pageSize, elems.Count);
        }

        private IEnumerable<CatalogItem> generateCatalogItems(int count)
        {
            for (int i = 0; i < count; i++)
                yield return new CatalogItem
                {
                    Id = i,
                    Name = Faker.Lorem.Words(3).ToString(),
                    Description = Faker.Lorem.Sentence(10),
                };
        }

    }
}
