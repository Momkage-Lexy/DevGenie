using Microsoft.AspNetCore.Mvc;
using DevGenie.Services;

namespace DevGenie.Controllers
{
    public class ScraperController : Controller
    {
        private readonly ISeleniumService _seleniumService;

        public ScraperController(ISeleniumService seleniumService)
        {
            _seleniumService = seleniumService;
        }

        public IActionResult Index(string browser = "chrome")
        {
            string url = "https://www.microsoft.com";
            string pageTitle = _seleniumService.GetPageTitle(url, browser);

            return Content($"Page Title: {pageTitle} (Scraped using {browser})");
        }
    }
}
