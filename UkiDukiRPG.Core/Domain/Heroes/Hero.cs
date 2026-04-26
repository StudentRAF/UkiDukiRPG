using System.Text;

using UkiDukiRPG.Core.Domain.Stats;

namespace UkiDukiRPG.Core.Domain.Heroes;

public interface IHero
{
    StatBlock EffectiveStatBlock   { get; }
    StatBlock BaseStatBlock        { get; }
    StatBlock ProgressionStatBlock { get; }

    float CurrentHealth { get; set; }
}

public class Hero : IHero
{
    public string Name          { get; }
    public float  CurrentHealth { get; set; }

    public StatBlock BaseStatBlock        { get; }
    public StatBlock ProgressionStatBlock { get; }

    //NOTE: Should not subscribe to events of this instance because whenever stats are changing, this instance will be changes as well
    public StatBlock EffectiveStatBlock => m_TotalStatBlock;

    private StatBlock m_TotalStatBlock;

    public Hero(string name, StatBlock baseStatBlock, StatBlock progressionStatBlock)
    {
        Name                 = name;
        BaseStatBlock        = baseStatBlock;
        ProgressionStatBlock = progressionStatBlock;

        m_TotalStatBlock = BaseStatBlock + ProgressionStatBlock;

        ProgressionStatBlock.Attack.OnModified  += _ => m_TotalStatBlock = BaseStatBlock + ProgressionStatBlock;
        ProgressionStatBlock.Health.OnModified  += _ => m_TotalStatBlock = BaseStatBlock + ProgressionStatBlock;
        ProgressionStatBlock.Defense.OnModified += _ => m_TotalStatBlock = BaseStatBlock + ProgressionStatBlock;
        ProgressionStatBlock.Magic.OnModified   += _ => m_TotalStatBlock = BaseStatBlock + ProgressionStatBlock;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Name: {Name}")
               .AppendLine("BaseStats: ")
               .AppendLine(BaseStatBlock.ToString())
               .AppendLine("ProgressionStats: ")
               .AppendLine(ProgressionStatBlock.ToString())
               .AppendLine("TotalStats: ")
               .AppendLine(EffectiveStatBlock.ToString());

        return builder.ToString();
    }
}
