using Character.Ability.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Drag;

namespace Character.Ability.UI
{
    public class SkillList : MonoBehaviour
    {
        [SerializeField] GameObject skillBoxPrefab;
        [SerializeField] Transform contentTR;

        public void AddSkillData(Skill skill, int level)
        {
            SkillBox skillBox = Instantiate(skillBoxPrefab, contentTR).GetComponent<SkillBox>();
            skillBox.FillBoxWithSkill(skill, level);
        }
    }
}
