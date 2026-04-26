using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Effects;

//NOTE: Used by Witch's Curse and Dragon's Intimidate.
public class AttackDecreaseEffect(
    float             baseDecrease,
    float             decreaseFactor,
    TimeInterval      duration,
    Func<IHero, float> attackerModifierFunction,
    Func<IHero, float> defenderModifierFunction,
    IScheduler        scheduler
) : DebuffEffect(nameof(AttackDecreaseEffect), duration, scheduler)
{
    private readonly Func<IHero, float> m_AttackerModifierFunction = attackerModifierFunction;
    private readonly Func<IHero, float> m_DefenderModifierFunction = defenderModifierFunction;

    private readonly float m_BaseDecrease   = baseDecrease;
    private readonly float m_DecreaseFactor = decreaseFactor;
    private          int   m_Decrease       = 0;

    public override void Apply(IHero attacker, IHero defender)
    {
        var attackerModifier = m_AttackerModifierFunction(attacker);
        var defenderModifier = m_DefenderModifierFunction(defender);

        m_Decrease = (int)((defender.EffectiveStatBlock.Attack.Level - m_BaseDecrease) * (1 - m_DecreaseFactor) * attackerModifier * defenderModifier);
        
        defender.ProgressionStatBlock.Attack.Descend(m_Decrease);

        ScheduleClear(defender);
    }

    public override void Clear(IHero defender)
    {
        defender.ProgressionStatBlock.Attack.Ascend(m_Decrease);
    }
}
