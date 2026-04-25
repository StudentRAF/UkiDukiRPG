namespace UkiDukiRPG.Core.Domain.Time;

public enum TimeUnit
{
    Tick,
    Turn,
    Round,
}

public readonly struct TimeInterval(int ticks = 0)
{
    public int Ticks { get; } = ticks;

    public static TimeInterval FromTurns(int turns) => new(turns);

    public static TimeInterval FromRounds(int rounds) => new(2 * rounds);

    public static TimeInterval FromTicks(int ticks) => new(ticks);

    public static TimeInterval From(int interval, TimeUnit timeUnit)
    {
        return timeUnit switch
               {
                   TimeUnit.Tick  => FromTicks(interval),
                   TimeUnit.Turn  => FromTurns(interval),
                   TimeUnit.Round => FromRounds(interval),
                   _              => FromTicks(0)
               };
    }
}
