namespace UkiDukiRPG.Core.Domain.Stats;

public enum StatType
{
    None = 0,
    
    Health,
    Attack,
    Defense,
    Magic,

    Count, //NOTE: hack to get array size value required to hold the types, always keep as last element
}

public class StatModifiedArgs
{
    public int PreviousLevel { get; set; }
    public int CurrentLevel  { get; set; }
}

public abstract class Stat(StatType statType, int level = 0)
{
    public int      Level { get; private set; } = level;
    public StatType Type  { get; }              = statType;

    public event Action<StatModifiedArgs> OnModified = delegate { };

    public void Ascend() => Ascend(1);
    
    public void Ascend(int amount)
    {
        Level += amount;
        
        OnModified(new StatModifiedArgs { PreviousLevel = Level - amount, CurrentLevel = Level });
    }
    
    public void Descend(int amount)
    {
        //NOTE: for now this value is trusted to be correct (Level will not go below zero)
        Level -= amount;
        
        OnModified(new StatModifiedArgs { PreviousLevel = Level + amount, CurrentLevel = Level });
    }
}