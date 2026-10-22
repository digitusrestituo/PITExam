using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1.Tests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(@"C:\Browser_drivers\", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.ebay.com";
        }

        [Test]
        public void Test1_field()
        {
            Assert.That(driver.FindElements(By.Id("gh-ac")).Count > 0,
                        "Meklēšanas lauks ar id 'gh-ac' nav atrasts");
        }

        [Test]
        public void Test2_search()
        {
            Assert.That(driver.FindElements(By.Id("gh-btn")).Count > 0,
                        "Meklēšanas poga ar id 'gh-btn' nav atrasta");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}