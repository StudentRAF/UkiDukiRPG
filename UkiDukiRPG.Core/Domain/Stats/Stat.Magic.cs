namespace UkiDukiRPG.Core.Domain.Stats;

public class MagicStat(int level = 0) : Stat(StatType.Magic, level)
{
    public static MagicStat operator+(MagicStat left, MagicStat right) => new(left.Level + right.Level);
}
