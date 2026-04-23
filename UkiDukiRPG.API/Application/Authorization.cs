namespace UkiDukiRPG.API.Application;

public static class AuthorizationExtensions
{
    public static IServiceCollection SetupAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization();
        
        return services;
    }
}
