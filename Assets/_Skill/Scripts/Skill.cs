using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Ability.Enum;
using Character.Ability.Data;

namespace Character.Ability
{
    public abstract class Skill : MonoBehaviour
    {
        [SerializeField] protected SkillData data;
        protected int level;

        public SkillData Data { get { return data; } }
        public int Level { get { return level; } }

        public virtual void Init(SkillData data)
        {
            this.data = data;
        }
        public abstract void Use();
        public abstract string GetDesc();

        public virtual bool LevelUp()
        {
            if(level < Data.maxLevel)
            {
                level++;
                return true;
            }
            return false;
        }
    }
}