namespace UkiDukiRPG.Core.Domain.Stats;

public class AttackStat(int level = 0) : Stat(StatType.Attack, level)
{
    public static AttackStat operator+(AttackStat left, AttackStat right) => new(left.Level + right.Level);
    
    public float EffectMultiplier() => 1 + 0.067f * Level;
}
