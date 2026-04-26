using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Effects;

//NOTE: Used by Knight's Battle Cry and Goblin Warrior's Frenzy.
public class AttackIncreaseEffect(
    float              baseIncrease,
    float              increaseFactor,
    TimeInterval       duration,
    Func<IHero, float> attackerModifierFunction,
    Func<IHero, float> defenderModifierFunction,
    IScheduler         scheduler
) : BuffEffect(nameof(AttackIncreaseEffect), duration, scheduler)
{
    private readonly Func<IHero, float> m_AttackerModifierFunction = attackerModifierFunction;
    private readonly Func<IHero, float> m_DefenderModifierFunction = defenderModifierFunction;

    private readonly float m_BaseIncrease   = baseIncrease;
    private readonly float m_IncreaseFactor = increaseFactor;
    private          int   m_Increase       = 0;

    public override void Apply(IHero attacker, IHero defender)
    {
        var attackerModifier = m_AttackerModifierFunction(attacker);
        var defenderModifier = m_DefenderModifierFunction(defender);

        m_Increase = (int)((attacker.EffectiveStatBlock.Attack.Level + m_BaseIncrease) * m_IncreaseFactor * attackerModifier * defenderModifier);

        attacker.ProgressionStatBlock.Attack.Ascend(m_Increase);

        ScheduleClear(attacker);
    }

    public override void Clear(IHero attacker)
    {
        attacker.ProgressionStatBlock.Attack.Descend(m_Increase);
    }
}
