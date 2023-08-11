using Character.Ability.Enum;

namespace Character.Buff
{
    public class BuffAttack : Buff
    {
        protected override void onBuff()
        {
            switch (calType)
            {
                case EValueType.Absolute:
                    Player.Instance.Stat.runTimeAttack += value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeAttack *= value;
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
                    Player.Instance.Stat.runTimeAttack -= value;
                    break;
                case EValueType.Multiple:
                    Player.Instance.Stat.runTimeAttack *= 1 / value;
                    break;
                default:
                    break;
            }
        }
    }
}
