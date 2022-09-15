﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using ProgrammableLEDUI.Platforms.Windows;
using ProgrammableLEDUI.Services;

namespace ProgrammableLEDUI;

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
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

#if WINDOWS
        builder.Services.AddTransient<IProjectService, ProjectServiceWindows>();
#endif


        return builder.Build();
    }
}
