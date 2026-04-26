namespace UkiDukiRPG.Core.Domain.Stats;

public class HealthStat(int level = 0) : Stat(StatType.Health, level)
{
    public static HealthStat operator+(HealthStat left, HealthStat right) => new(left.Level + right.Level);
    
    public float MaxHealth() => Level * 16.75f;
}
