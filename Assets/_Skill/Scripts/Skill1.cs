using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class Skill1 : ActiveSkill
    {
        public override bool Use()
        {
            Debug.Log("Hello");

            return false;
        }
        public override string GetDesc()
        {
            return "yes";
        }
    }
}
