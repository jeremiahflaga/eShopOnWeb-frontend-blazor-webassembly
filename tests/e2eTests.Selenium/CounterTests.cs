using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace e2eTests.Selenium
{
    // NOTE: seems like these Selenium tests assumes that the app is already running
    // before you run the tests
    public sealed class CounterTests : IDisposable
    {
        private IWebDriver driver;
        private string appURL;

        public CounterTests()
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
        public void ShouldDisplayTestDiv()
        {
            driver.Navigate().GoToUrl(appURL + "/counter");
            var elem = driver.WaitUntilVisible(By.CssSelector("[data-test='test']"));

            Assert.NotNull(elem);
            Assert.Equal("Hello, world!", elem.Text);
            driver.Quit();
        }

        [Fact]
        public void ShouldIncrementCount()
        {
            driver.Navigate().GoToUrl(appURL + "/counter");
            Assert.Equal("Current count: 0", driver.WaitUntilVisible(By.CssSelector("p")).Text);
            driver.WaitUntilClickable(By.CssSelector(".btn")).Click();
            Assert.Equal("Current count: 1", driver.WaitUntilVisible(By.CssSelector("p")).Text);
            driver.Quit();
        }
    }
}
