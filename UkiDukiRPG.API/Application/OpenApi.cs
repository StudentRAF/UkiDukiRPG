namespace UkiDukiRPG.API.Application;

public static class OpenApiExtensions
{
    public static IServiceCollection SetupOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi();
        
        return services;
    }
}
