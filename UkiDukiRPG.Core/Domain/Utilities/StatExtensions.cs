using UkiDukiRPG.Core.Domain.Stats;

namespace UkiDukiRPG.Core.Domain.Utilities;

public static class StatExtensions
{
    extension(StatBlock statBlock)
    {
        public float MaxHealth() => statBlock.Health.MaxHealth();
    }
}
