namespace UkiDukiRPG.API.Application;

public static class LoggingExtensions
{
    public static ILoggingBuilder SetupLogging(this WebApplicationBuilder builder)
    {
        return builder.Logging;
    }
}
