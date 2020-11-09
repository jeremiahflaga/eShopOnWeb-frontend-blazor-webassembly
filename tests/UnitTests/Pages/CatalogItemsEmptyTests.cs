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
	public class CatalogItemsEmptyTests
	{
        [Fact]
        public void ShouldShowLoading()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.Services.AddScoped(x => new Mock<Microsoft.Extensions.Configuration.IConfiguration>().Object);
            ctx.Services.AddScoped(x => new Mock<ICatalogService>().Object);
            var sut = ctx.RenderComponent<CatalogItems>();

            // Act
            var elem = sut.Find("[data-test='loading']");

            // Assert
            Assert.NotNull(elem);
        }
    }
}
