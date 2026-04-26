using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Effects;

public abstract class Effect(string name, IScheduler scheduler)
{
    public string Name { get; } = name;

    protected readonly IScheduler m_Scheduler = scheduler;

    public abstract void Apply(IHero attacker, IHero defender);
}

public abstract class InstantEffect(string name, IScheduler scheduler) : Effect(name, scheduler) { }

public enum StatusEffectCategory
{
    Buff,
    Debuff,
}

public abstract class StatusEffect(string name, TimeInterval duration, IScheduler scheduler) : Effect(name, scheduler)
{
    public TimeInterval Duration { get; } = duration;

    protected void ScheduleClear(IHero hero) => m_Scheduler.Schedule(() => Clear(hero), Duration);

    public abstract void Clear(IHero hero);

    public abstract StatusEffectCategory Category();
}

public abstract class BuffEffect(string name, TimeInterval duration, IScheduler scheduler) : StatusEffect(name, duration, scheduler)
{
    public override StatusEffectCategory Category() => StatusEffectCategory.Buff;
}

public abstract class DebuffEffect(string name, TimeInterval duration, IScheduler scheduler) : StatusEffect(name, duration, scheduler)
{
    public override StatusEffectCategory Category() => StatusEffectCategory.Debuff;
}

//NOTE: Apply(hero, hero) -> without the need to think about attack/defender if effect is self applied 
