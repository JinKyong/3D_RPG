
using Character.Buff;

namespace Character.Ability
{
    public class Skill3 : ActiveSkill
    {
        public override void Use()
        {
            BuffManager.Instance.OnBuffBySkill(BuffManager.EBuffType.Speed, this);
        }
        public override string GetDesc()
        {
            return string.Format(data.skillDesc,
                   data.mana[level],
                   data.duration[level],
                   data.value[level]);
        }
    }
}