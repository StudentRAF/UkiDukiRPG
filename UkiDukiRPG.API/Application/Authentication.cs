namespace UkiDukiRPG.API.Application;

public static class AuthenticationExtensions
{
    public static IServiceCollection SetupAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication();
        
        return services;
    }
}
