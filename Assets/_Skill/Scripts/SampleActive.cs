using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class SampleActive : ActiveSkill
    {
        public override void Use()
        {
            Debug.Log("Active");
        }
    }
}
