
using Character.Ability.Enum;

namespace Character.Buff
{
    public class BuffHealth : Buff
    {
        protected override void onBuff()
        {
            switch (calType)
            {
                case EValueType.Absolute:
                    Player.Instance.Stat.runTimeMaxHealth += value;
                    Player.Instance.Stat.runTimeHealth += value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeMaxHealth *= value;
                    Player.Instance.Stat.runTimeHealth *= value;
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
                    Player.Instance.Stat.runTimeMaxHealth -= value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeMaxHealth *= 1 / value;
                    break;
                default:
                    break;
            }
        }
    }
}