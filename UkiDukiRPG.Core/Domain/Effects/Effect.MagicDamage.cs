using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Effects;

//NOTE: Used by Shadow Bolt, Drain Life, Flame Breath, Firebolt, Mana Drain.
public class MagicDamageEffect(float baseDamage, Func<IHero, float> attackerModifierFunction, Func<IHero, float> defenderModifierFunction, IScheduler scheduler)
: InstantEffect(nameof(MagicDamageEffect), scheduler)
{
    private readonly float             m_BaseDamage               = baseDamage;
    private readonly Func<IHero, float> m_AttackerModifierFunction = attackerModifierFunction;
    private readonly Func<IHero, float> m_DefenderModifierFunction = defenderModifierFunction;

    public override void Apply(IHero attacker, IHero defender)
    {
        var attackerModifier = m_AttackerModifierFunction(attacker);
        var defenderModifier = m_DefenderModifierFunction(defender);

        var newHealth = defender.CurrentHealth - m_BaseDamage * attackerModifier * defenderModifier;

        defender.CurrentHealth = float.Max(0f, newHealth);
    }
}
