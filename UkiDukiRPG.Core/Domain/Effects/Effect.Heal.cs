using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;
using UkiDukiRPG.Core.Domain.Utilities;

namespace UkiDukiRPG.Core.Domain.Effects;

//NOTE: Used by the Knight's Second Wind.
public class HealEffect(float baseHeal, Func<IHero, float> attackerModifierFunction, Func<IHero, float> defenderModifierFunction, IScheduler scheduler)
: InstantEffect(nameof(HealEffect), scheduler)
{
    private readonly float             m_BaseHeal                 = baseHeal;
    private readonly Func<IHero, float> m_AttackerModifierFunction = attackerModifierFunction;
    private readonly Func<IHero, float> m_DefenderModifierFunction = defenderModifierFunction;

    public override void Apply(IHero attacker, IHero defender)
    {
        var attackerModifier = m_AttackerModifierFunction(attacker);
        var defenderModifier = m_DefenderModifierFunction(defender);

        var maxHealth = attacker.EffectiveStatBlock.MaxHealth();
        var newHealth = attacker.CurrentHealth + m_BaseHeal * attackerModifier * defenderModifier;

        attacker.CurrentHealth = float.Min(maxHealth, newHealth);
    }
}
