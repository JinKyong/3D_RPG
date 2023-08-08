
using Character.Ability.Enum;

namespace Character.Buff
{
    public class BuffSpeed : Buff
    {
        protected override void onBuff()
        {
            switch (calType)
            {
                case EValueType.Absolute:
                    Player.Instance.Stat.runTimeSpeed += value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeSpeed *= value;
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
                    Player.Instance.Stat.runTimeSpeed -= value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeSpeed *= 1 / value;
                    break;
                default:
                    break;
            }
        }
    }
}