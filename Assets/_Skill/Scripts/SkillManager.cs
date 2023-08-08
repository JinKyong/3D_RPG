using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using UnityEditor;
using Character.Ability.Data;
using Character.Ability.UI;
using System.Linq;
using Utils.Drag;

namespace Character.Ability
{
    public class SkillManager : Singleton<SkillManager>
    {
        [SerializeField] SkillList list;

        [SerializeField] string dataPath;
        [SerializeField] string namespaceName;
        [SerializeField] string skillName;

        Dictionary<int, int> skillDict;
        int skillPoint;
        public int Point { get { return skillPoint; } }

        void Start()
        {
            skillDict = new Dictionary<int, int>();
            skillPoint = 0;

            AddSkill(0);
            //AddSkill(1);

            Skill skill = transform.GetChild(0).GetComponent<Skill>();
            skill.LevelUp();
            list.AddSkillData(skill);
        }

        public void AddSkill(int num)
        { 
            //네임스페이스.이름 으로 해야 찾음
            string componentName = namespaceName + skillName + num;
            System.Type componentType = System.Type.GetType(componentName);

            GameObject skillObj = new GameObject();
            skillObj.name = skillName + num;
            skillObj.transform.SetParent(transform);
            skillObj.AddComponent(componentType);

            Skill skill = skillObj.GetComponent<Skill>();
            skill.Init(GetSkillDataByNum(num));
        }

        public SkillData GetSkillDataByNum(int num)
        {
            string path = dataPath + $"/SkillData{num}.asset";
            return AssetDatabase.LoadAssetAtPath<SkillData>(path);
        }
        public int GetLevelBySkillNum(int num)
        {
            if (skillDict.ContainsKey(num))
            {
                return skillDict[num];
            }
            else
            {
                return 0;
            }
        }
        public void UpdateDataToDict(int num, int level)
        {
            if (level < 0) return;

            skillDict[num] = level;
        }
        public void ResetData()
        {
            foreach (var a in skillDict.Keys.ToList())
            {
                skillPoint += skillDict[a];
                skillDict[a] = 0;
            }
        }

    }
}
