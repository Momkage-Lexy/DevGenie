using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using System;

namespace DevGenie.Services
{
    public class SeleniumService : ISeleniumService
    {
        public string GetPageTitle(string url, string browser = "chrome")
        {
            IWebDriver driver = GetWebDriver(browser);

            try
            {
                driver.Navigate().GoToUrl(url);

                // Get the page title
                string title = driver.Title;

                return title;
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }

        private IWebDriver GetWebDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--headless");
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--headless");
                    return new EdgeDriver(edgeOptions);

                case "safari":
                    // Safari does not support headless mode
                    return new SafariDriver();

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }
    }
}

