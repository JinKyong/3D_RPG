using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability
{
    public class SamplePassive : PassiveSkill
    {
        public override void Use()
        {
            Debug.Log("Hi");
        }

    }
}