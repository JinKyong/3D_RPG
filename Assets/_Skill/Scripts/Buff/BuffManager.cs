using Character.Ability;
using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Buff
{
    public class BuffManager : Singleton<BuffManager>
    {
        [SerializeField] Dictionary<EBuffType, Buff> buffPrefabs;

        public enum EBuffType
        {
            Health,
            Mana,
            Attack,
            Speed
        }
        private void Start()
        {
            Buff buff = new BuffSpeed();
            buffPrefabs.Add(EBuffType.Speed, buff);
        }

        public void OnBuffBySkill(EBuffType buffType, Skill skill)
        {
            Buff buff = buffPrefabs[buffType];
            int level = skill.Level;
            buff.Init(skill.Data.duration[level], skill.Data.value[level]);
        }
        //public void OnBuffByItem(EBuffType buffType, Item item)
    }
}
