using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace e2eTests.Selenium
{
    // from C# Selenium 'ExpectedConditions is obsolete' - https://stackoverflow.com/a/57846288/1451757
    internal static class SeleniumWaitExtensions
    {
        // use: element = driver.WaitUntilVisible(By.XPath("//input[@value='Save']"));
        public static IWebElement WaitUntilVisible(
            this IWebDriver driver,
            By itemSpecifier,
            int secondsTimeout = 10)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsTimeout));
            var element = wait.Until<IWebElement>(driver =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(itemSpecifier);
                    if (elementToBeDisplayed.Displayed)
                        return elementToBeDisplayed;

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            });
            return element;
        }

        public static IWebElement WaitUntilClickable(
            this IWebDriver driver,
            By itemSpecifier,
            int secondsTimeout = 10)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsTimeout));
            var element = wait.Until<IWebElement>(driver =>
            {
                try
                {
                    // from https://sqa.stackexchange.com/a/14562
                    if (secondsTimeout > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsTimeout));
                        return wait.Until(drv => drv.FindElement(itemSpecifier));
                    }
                    return driver.FindElement(itemSpecifier);
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            });
            return element;
        }
    }
}
