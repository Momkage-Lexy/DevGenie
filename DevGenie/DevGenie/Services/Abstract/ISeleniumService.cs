namespace DevGenie.Services
{
    public interface ISeleniumService
    {
        string GetPageTitle(string url, string browser = "chrome");
    }
}
