using Character.Buff;
using UnityEngine;

namespace Character.Ability
{
    public class Skill0 : ActiveSkill
    {
        public override void Use()
        {
            BuffManager.Instance.OnBuffBySkill(BuffManager.EBuffType.Health, this);

            GameObject effect = Instantiate(data.effect);
            effect.transform.position = Player.Instance.transform.position;
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