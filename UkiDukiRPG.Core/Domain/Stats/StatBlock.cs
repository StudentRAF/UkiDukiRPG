using System.Text;

namespace UkiDukiRPG.Core.Domain.Stats;

public class StatBlock
{
    public HealthStat  Health  { get; }
    public AttackStat  Attack  { get; }
    public DefenseStat Defense { get; }
    public MagicStat   Magic   { get; }

    private readonly Action[]      m_StatLevelUpActions;
    private readonly Action<int>[] m_StatAscendActions;
    private readonly Action<int>[] m_StatDescendActions;

    public StatBlock(int health = 0, int attack = 0, int defense = 0, int magic = 0) : this(new HealthStat(health), new AttackStat(attack), new DefenseStat(defense),
                                                                                            new MagicStat(magic)) { }

    public StatBlock(HealthStat health, AttackStat attack, DefenseStat defense, MagicStat magic)
    {
        Health  = health;
        Attack  = attack;
        Defense = defense;
        Magic   = magic;

        m_StatLevelUpActions = new Action[(int)StatType.Count];
        m_StatAscendActions  = new Action<int>[(int)StatType.Count];
        m_StatDescendActions = new Action<int>[(int)StatType.Count];

        m_StatLevelUpActions[(int)Health.Type]  = Health.Ascend;
        m_StatLevelUpActions[(int)Attack.Type]  = Attack.Ascend;
        m_StatLevelUpActions[(int)Defense.Type] = Defense.Ascend;
        m_StatLevelUpActions[(int)Magic.Type]   = Magic.Ascend;

        m_StatAscendActions[(int)Health.Type]  = Health.Ascend;
        m_StatAscendActions[(int)Attack.Type]  = Attack.Ascend;
        m_StatAscendActions[(int)Defense.Type] = Defense.Ascend;
        m_StatAscendActions[(int)Magic.Type]   = Magic.Ascend;

        m_StatDescendActions[(int)Health.Type]  = Health.Descend;
        m_StatDescendActions[(int)Attack.Type]  = Attack.Descend;
        m_StatDescendActions[(int)Defense.Type] = Defense.Descend;
        m_StatDescendActions[(int)Magic.Type]   = Magic.Descend;
    }

    public void Ascend(StatType stat) => m_StatLevelUpActions[(int)stat]();

    public void Ascend(StatType stat, int amount) => m_StatAscendActions[(int)stat](amount);

    public void Descend(StatType stat, int amount) => m_StatDescendActions[(int)stat](amount);

    // @formatter:off
    public static StatBlock operator+(StatBlock left, StatBlock right) => new(left.Health  + right.Health,
                                                                              left.Attack  + right.Attack,
                                                                              left.Defense + right.Defense,
                                                                              left.Magic   + right.Magic);
    // @formatter:on

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Health: {Health.Level}")
               .AppendLine($"Attack: {Attack.Level}")
               .AppendLine($"Defense: {Defense.Level}")
               .AppendLine($"Magic: {Magic.Level}");

        return builder.ToString();
    }
}
