using BlazorWebAssemblyApp.Pages;
using Bunit;
using System;
using Xunit;

namespace UnitTests
{
    // REFERENCES: 
    // Test components in ASP.NET Core Blazor: https://docs.microsoft.com/en-us/aspnet/core/blazor/test?view=aspnetcore-3.1
    // Creating a new bUnit Test Project: https://bunit.egilhansen.com/docs/getting-started/create-test-project.html?tabs=xunit
    // Writing Tests in C# for Blazor Components: https://bunit.egilhansen.com/docs/getting-started/writing-csharp-tests.html?tabs=xunit

    public class CounterTests
    {
        [Fact]
        public void ShouldShowTestDiv()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Act
            var element = cut.Find("[data-test='test']");

            // Assert
            Assert.NotNull(element);
            Assert.Equal("Hello, world!", element.TextContent);
        }

        [Fact]
        public void CounterShouldIncrementWhenSelected()
        {
            // Arrange
            // Use bUnit to render the component under test, pass in its parameters, inject required services, 
            // and access the rendered component instance and the markup it has produced.
            // Rendering a component happens through bUnit's TestContext. The result of the rendering 
            // - a IRenderedComponent<TComponent> - provides access to the component instance and the markup 
            // produced by the component.
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var element = cut.Find("p");

            // Act
            cut.Find("button").Click();
            var elemText = element.TextContent;

            // Assert
            elemText.MarkupMatches("Current count: 1");
        }
    }
}
