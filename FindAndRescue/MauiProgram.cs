﻿using FindAndRescue.Services;
using Microsoft.Extensions.Logging;

namespace FindAndRescue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<RescueService>();
            builder.Services.AddSingleton<RescueViewModel>();
            builder.Services.AddTransient<RescueDetailsViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailsPage>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
