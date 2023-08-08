using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Ability.Enum;


namespace Character.Ability.Data
{
    [CreateAssetMenu(fileName ="SkillData",
        menuName ="ScriptableObjects/Skill/Data")]
    public class SkillData : ScriptableObject
    {
        [Header("Info")]
        public Sprite skillImage;
        public int skillNumber;
        public string skillName;
        public string skillDesc;
        public ESkillType skillType;
        public EValueType valueType;

        [Header("Stat")]
        [Space]
        public int maxLevel;
        public float[] value;
        public float[] duration;
        public float[] mana;
        public float range;
        public float precast;
        public float postcast;

        [Header("Component")]
        [Space]
        public GameObject effect;
        public AnimationClip animClip;
    }
}

