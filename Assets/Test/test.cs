using Character.Ability;
using System.Collections;
using System.Collections.Generic;
using UI.Slot;
using UnityEngine;

namespace Test
{
    public class test : MonoBehaviour
    {
        public KeySlot slot;
        public Skill skill;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                skill = FindObjectOfType<Skill>();
                slot.FillWithSkill(skill);
            }
        }

        public void TestInput()
        {
            slot.FillWithSkill(skill);
        }
    }
}