using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class Skill0 : ActiveSkill
    {
        public override void Use()
        {
            StartCoroutine(UseSkill());
        }
        public override string GetDesc()
        {
            return string.Format(data.skillDesc, 
                data.mana[level],
                data.duration[level],
                data.value[level]);
        }

        IEnumerator UseSkill()
        {
            //player��ġ�� ����Ʈ ����
            yield return new WaitForSeconds(data.precast);
            //ȿ�� �ߵ�
            
        }
    }
}