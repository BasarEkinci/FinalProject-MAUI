using FinalProject.DataTransactions;
using Microsoft.Extensions.Logging;

namespace FinalProject
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "Student.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DBTrans>(s, databasePath));

            return builder.Build();
        }
    }
}
