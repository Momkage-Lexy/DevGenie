using System.Net.Http.Headers;
using DevGenie.Services;
namespace DevGenie;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string openAiApiKey = builder.Configuration["DevGenieKey"];
        string openAiUrl = "https://api.openai.com/v1/chat/completions";

        builder.Services.AddHttpClient<IOpenAiService, OpenAiService>((httpClient, services) =>
        {
            httpClient.BaseAddress = new Uri(openAiUrl);           
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiApiKey);
            return new OpenAiService(httpClient, services.GetRequiredService<ILogger<OpenAiService>>());
        });

        // Add Services to the container
        builder.Services.AddScoped<ISeleniumService, SeleniumService>();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
