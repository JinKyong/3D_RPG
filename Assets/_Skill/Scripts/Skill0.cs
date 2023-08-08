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
            //player위치에 이펙트 생성
            yield return new WaitForSeconds(data.precast);
            //효과 발동
            
        }
    }
}