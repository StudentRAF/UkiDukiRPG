using UkiDukiRPG.Core.Domain.Heroes;
using UkiDukiRPG.Core.Domain.Time;

namespace UkiDukiRPG.Core.Domain.Abilities;

public abstract class Ability(string name)
{
    public string Name { get; } = name;

    public abstract void Use(IHero caster, IHero target);
}
