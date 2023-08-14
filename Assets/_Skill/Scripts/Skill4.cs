
using Character.Buff;
using UnityEngine;

namespace Character.Ability
{
    public class Skill4 : ActiveSkill
    {
        public override void Use()
        {
            BuffManager.Instance.OnBuffBySkill(BuffManager.EBuffType.Speed, this);

            GameObject effect = Instantiate(data.effect);
            Vector3 pos = Player.Instance.transform.position;
            pos.y -= 1f;
            effect.transform.position = pos;
        }
        public override string GetDesc()
        {
            return string.Format(data.skillDesc,
                   data.mana[level],
                   data.value[level]);
        }
    }
}