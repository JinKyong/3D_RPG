using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class Skill0 : ActiveSkill
    {
        public override void Use()
        {
            Debug.Log("Active");
        }
        public override string GetDesc()
        {
            return string.Format(data.skillDesc, 1, 2, 3);
        }
    }
}