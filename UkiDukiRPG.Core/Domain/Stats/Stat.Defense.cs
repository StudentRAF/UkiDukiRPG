namespace UkiDukiRPG.Core.Domain.Stats;

public class DefenseStat(int level = 0) : Stat(StatType.Defense, level)
{
    public static DefenseStat operator+(DefenseStat left, DefenseStat right) => new(left.Level + right.Level);
    
    public float EffectMultiplier() => 0.01f *  Level;
}
