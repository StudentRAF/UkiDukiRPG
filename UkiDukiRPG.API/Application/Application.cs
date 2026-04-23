namespace UkiDukiRPG.API.Application;

public class Application
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.SetupLogging();
        
        builder.Services.SetupValidation();
        builder.Services.SetupImplementedServices();
        builder.Services.SetupHostedServices();
        builder.Services.SetupBackgroundServices();
        builder.Services.SetupDatabase();
        builder.Services.SetupHttpServices();
        builder.Services.SetupCors();
        builder.Services.SetupAuthentication();
        builder.Services.SetupAuthorization();
        builder.Services.SetupOpenApi();
        
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
