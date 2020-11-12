using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace e2eTests.Selenium.Catalog
{
    public class Catalog_SuccessTests : IDisposable
	{
        private IWebDriver driver;
        private string appURL;

        public Catalog_SuccessTests()
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

		[Fact]
		public void shows_catalog_items()
		{
			driver.Navigate().GoToUrl(appURL + "/catalog-items");
			var elem = driver.WaitUntilVisible(By.CssSelector("[data-test='catalog-items']"));

			Assert.NotNull(elem);
			driver.Quit();
		}

		[Fact]
		public void shows_pagination()
		{
			driver.Navigate().GoToUrl(appURL + "/catalog-items");
			var elem = driver.WaitUntilVisible(By.CssSelector("[data-test='pagination']"));

			Assert.NotNull(elem);
			driver.Quit();
		}

        [Fact]
        public void shows_correct_number_of_catalog_items_on_first_page()
        {
            var pageSize = 5;
            driver.Navigate().GoToUrl(appURL + "/catalog-items");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test='catalog-item']")));
            var elems = driver.FindElements(By.CssSelector("[data-test='catalog-item']"));

            Assert.NotNull(elems);
            Assert.Equal(pageSize, elems.Count);
            driver.Quit();
        }
    }
}
