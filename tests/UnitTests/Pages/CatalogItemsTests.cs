using AngleSharp.Text;
using BlazorWebAssemblyApp.Pages;
using Bunit;
using System;
using Xunit;

namespace Pages
{
	public class CatalogItemsTests
	{
        [Fact]
        public void ShouldShowCatalogItems()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Act
            var paraElm = cut.Find("[data-test='catalog-items']");

            // Assert
            Assert.NotNull(paraElm);
        }
    }
}
