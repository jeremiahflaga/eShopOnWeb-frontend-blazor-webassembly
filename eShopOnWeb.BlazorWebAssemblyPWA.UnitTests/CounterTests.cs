using Bunit;
using eShopOnWeb.BlazorWebAssemblyPWA.Pages;
using System;
using Xunit;

namespace eShopOnWeb.BlazorWebAssemblyPWA.UnitTests
{
	public class CounterTests
	{
        // References: 
        // Test components in ASP.NET Core Blazor: https://docs.microsoft.com/en-us/aspnet/core/blazor/test?view=aspnetcore-3.1
        // Creating a new bUnit Test Project: https://bunit.egilhansen.com/docs/getting-started/create-test-project.html?tabs=xunit
        [Fact]
        public void CounterShouldIncrementWhenSelected()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");

            // Act
            cut.Find("button").Click();
            var paraElmText = paraElm.TextContent;

            // Assert
            paraElmText.MarkupMatches("Current count: 1");
        }
    }
}
