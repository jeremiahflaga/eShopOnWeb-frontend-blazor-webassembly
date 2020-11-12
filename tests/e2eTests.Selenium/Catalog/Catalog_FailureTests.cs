using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace e2eTests.Selenium.Catalog
{
	public class Catalog_FailureTests : IDisposable
    {
        private IWebDriver driver;
        private string appURL;

        public Catalog_FailureTests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            appURL = Environment.GetEnvironmentVariable("TestUrl");
            if (string.IsNullOrEmpty(appURL)) appURL = "http://localhost:5000";
            Console.WriteLine($"appURL is: {appURL}");
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        // NOTE_JBOY: Seems like tests for initial load are much harder (but
        // seems like not necessary anymore) in end to end tests
        //[Fact]
        //public void ShouldShowLoading()
        //{
        //    driver.Navigate().GoToUrl(appURL + "/catalog-items");
        //    var elem = driver.WaitUntilVisible(By.CssSelector("[data-test='loading']"));

        //    Assert.NotNull(elem);
        //    Assert.Equal("Loading...", elem.Text);
        //    driver.Quit();
        //}
    }
}
