using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class Skill1 : ActiveSkill
    {
        public override void Use()
        {
            Debug.Log("Hello");
        }
        public override string GetDesc()
        {
            return "yes";
        }
    }
}
