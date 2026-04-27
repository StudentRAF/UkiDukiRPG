using UkiDukiRPG.Core.Domain.Heroes;

namespace UkiDukiRPG.Core.Domain.Utilities;

//NOTE: Incomplete
public static class ModifierFunction
{
    public static Func<IHero, float> NoEffect => _ => 1.0f;
    
    public static Func<IHero, float> DefenseReduction => hero => (1.0f - hero.EffectiveStatBlock.Defense.EffectMultiplier());
    
    public static Func<IHero, float> AttackAmplification => hero => hero.EffectiveStatBlock.Attack.EffectMultiplier();
    
    public static Func<IHero, float> MagicAmplification => hero => hero.EffectiveStatBlock.Magic.EffectMultiplier();
}
