using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyPortfolio.Services;
using System.Net.Http.Headers;
using System.Reflection;

namespace MyPortfolio;

public static class MauiProgram
{

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.Services.AddMauiBlazorWebView();

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("MyPortfolio.appsettings.json")
            ?? throw new InvalidOperationException(
                "appsettings.json not found. Available resources: " +
                string.Join(", ", assembly.GetManifestResourceNames()));

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Services.AddHttpClient<IUserAuthClient, UserAuthClient>(client =>
        {
            client.BaseAddress = new Uri(config["ApiSettings:SecurityService"]);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        });
		
        builder.Services.AddHttpClient<ICandidateService, CandidateService>(client =>
        {
            client.BaseAddress = new Uri(config["ApiSettings:CandidateService"]);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();

#endif

        return builder.Build();
	}
}
