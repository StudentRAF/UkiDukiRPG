using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Effects;

//NOTE: Used by the Witch's Dark Pact
public class SacrificeEffect(float baseDamage, Func<IHero, float> attackerModifierFunction, Func<IHero, float> defenderModifierFunction, IScheduler scheduler)
: InstantEffect(nameof(SacrificeEffect), scheduler)
{
    private readonly float             m_BaseDamage               = baseDamage;
    private readonly Func<IHero, float> m_AttackerModifierFunction = attackerModifierFunction;
    private readonly Func<IHero, float> m_DefenderModifierFunction = defenderModifierFunction;

    public override void Apply(IHero attacker, IHero defender)
    {
        var attackerModifier = m_AttackerModifierFunction(attacker);
        var defenderModifier = m_DefenderModifierFunction(defender);

        var newHealth = attacker.CurrentHealth - m_BaseDamage * attackerModifier * defenderModifier;

        attacker.CurrentHealth = float.Max(0f, newHealth);
    }
}
