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
            buffPrefabs = new Dictionary<EBuffType, Buff>();

            Buff buffH = GetComponentInChildren<BuffHealth>();
            buffPrefabs.Add(EBuffType.Health, buffH);
            Buff buffM = GetComponentInChildren<BuffMana>();
            buffPrefabs.Add(EBuffType.Mana, buffM);
            Buff buffA = GetComponentInChildren<BuffAttack>();
            buffPrefabs.Add(EBuffType.Attack, buffA);
            Buff buffS = GetComponentInChildren<BuffSpeed>();
            buffPrefabs.Add(EBuffType.Speed, buffS);
        }

        public void OnBuffBySkill(EBuffType buffType, Skill skill)
        {
            Buff buff = buffPrefabs[buffType];
            int level = skill.Level;
            buff.Init(skill.Data.duration[level], skill.Data.value[level], skill.Data.valueType);
        }
        //public void OnBuffByItem(EBuffType buffType, Item item)
    }
}
