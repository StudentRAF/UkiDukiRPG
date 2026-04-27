using UkiDukiRPG.Core.Domain.Effects;
using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;
using UkiDukiRPG.Core.Domain.Utilities;

namespace UkiDukiRPG.Core.Domain.Abilities;

//NOTE: Effect 1: MagicDamageEffect (Target: Defender, Value: Light)
//      Effect 2: HealEffect (Target: Caster, Value: Light)
public class DrainLifeAbility(IScheduler scheduler) : Ability(nameof(DrainLifeAbility))
{
    private const float c_BaseDamage = 7.5f;

    private readonly IScheduler m_Scheduler = scheduler;

    public override void Use(IHero caster, IHero target)
    {
        var effect1 = new MagicDamageEffect(c_BaseDamage, ModifierFunction.MagicAmplification, ModifierFunction.NoEffect, m_Scheduler);

        var oldHealth = target.CurrentHealth;

        effect1.Apply(caster, target);

        var healthTaken = oldHealth - target.CurrentHealth;

        var effect2 = new HealEffect(healthTaken, ModifierFunction.NoEffect, ModifierFunction.NoEffect, m_Scheduler);

        effect2.Apply(caster, caster);
    }
}
