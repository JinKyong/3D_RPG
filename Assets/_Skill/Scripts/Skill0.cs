using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class Skill0 : ActiveSkill
    {
        public override bool Use()
        {
            Debug.Log("Active");

            return false;
        }
        public override string GetDesc()
        {
            return string.Format(data.skillDesc, 1, 2, 3);
        }
    }
}