namespace ResXapp;

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
            })
            .UseTinyMvvm(typeof(App).Assembly, typeof(App).Assembly);
        builder.Services.AddSingleton<IResxService, ResxService>();
        builder.Services.AddSingleton<IFileService, FileService>();

        builder.Services.AddSingleton<AppShell>();

        var app = builder.Build();

        Resolver.SetResolver(new ServiceProviderResolver(app.Services));

        return app;
    }
}
