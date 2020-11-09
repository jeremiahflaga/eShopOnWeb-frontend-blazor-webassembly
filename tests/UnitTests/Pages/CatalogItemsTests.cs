using AngleSharp;
using AngleSharp.Text;
using BlazorWebAssemblyApp.Pages;
using BlazorWebAssemblyApp.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pages
{
	public class CatalogItemsTests : TestContext
    {
        IRenderedComponent<CatalogItems> cut; // component under test

        public CatalogItemsTests()
        {
            // Arrange
            var catalogService = new Mock<ICatalogService>();
            catalogService.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(Task.FromResult(new BlazorWebAssemblyApp.Models.ListPagedCatalogItemResponse()));
            
            this.Services.AddScoped(x => new Mock<Microsoft.Extensions.Configuration.IConfiguration>().Object);
            this.Services.AddScoped(x => catalogService.Object);

            cut = this.RenderComponent<CatalogItems>();
        }

        [Fact]
        public void ShouldShowCatalogItems()
        {
            // Act
            var paraElm = cut.Find("[data-test='catalog-items']");

            // Assert
            Assert.NotNull(paraElm);
        }

        [Fact]
        public void ShouldShowPagination()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.Services.AddScoped(x => new Mock<Microsoft.Extensions.Configuration.IConfiguration>().Object);
            var catalogService = new Mock<ICatalogService>();
            catalogService.Setup(x => x.ListPagedCatalogItemsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new BlazorWebAssemblyApp.Models.ListPagedCatalogItemResponse()));
            ctx.Services.AddScoped(x => catalogService.Object);
            var cut = ctx.RenderComponent<CatalogItems>();

            // Act
            var paraElm = cut.Find("[data-test='pagination']");

            // Assert
            Assert.NotNull(paraElm);
        }
    }
}
