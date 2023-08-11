
using Character.Ability.Enum;

namespace Character.Buff
{
    public class BuffMana : Buff
    {
        protected override void onBuff()
        {
            switch (calType)
            {
                case EValueType.Absolute:
                    Player.Instance.Stat.runTimeMaxMana += value;
                    Player.Instance.Stat.runTimeMana += value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeMaxMana *= value;
                    Player.Instance.Stat.runTimeMana *= value;
                    break;
                default:
                    break;
            }
        }
        protected override void offBuff()
        {
            switch (calType)
            {
                case EValueType.Absolute:
                    Player.Instance.Stat.runTimeMaxMana -= value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeMaxMana *= 1 / value;
                    break;
                default:
                    break;
            }
        }
    }
}
