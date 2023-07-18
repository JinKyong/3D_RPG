using Character.Ability.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public abstract class PassiveSkill : Skill
    {
        public override void Init(SkillData skilldata)
        {
            base.Init(skilldata);

            Use();
        }
    }
}

