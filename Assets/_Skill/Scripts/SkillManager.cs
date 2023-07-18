using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using UnityEditor;
using Character.Ability.Data;
using Character.Ability.UI;
using System.Linq;

namespace Character.Ability
{
    public class SkillManager : Singleton<SkillManager>
    {
        [SerializeField] SkillList list;
        public string dataPath;

        Dictionary<int, int> skillDict;
        int skillPoint;
        public int Point { get { return skillPoint; } }


        void Start()
        {
            skillDict = new Dictionary<int, int>();
            skillPoint = 0;
            UpdateDataToDict(0, 5);
            UpdateDataToDict(1, 2);
            UpdateDataToDict(2, 5);
            UpdateDataToDict(3, 8);
            ResetData();

            list.AddSkillData(GetSkillDataByNum(0), skillDict[0]);
            list.AddSkillData(GetSkillDataByNum(0), skillDict[0]);
            list.AddSkillData(GetSkillDataByNum(0), skillDict[0]);
            list.AddSkillData(GetSkillDataByNum(0), skillDict[0]);
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

        public SkillData GetSkillDataByNum(int num)
        {
            string path = dataPath + $"/SkillData{num}.asset";
            return AssetDatabase.LoadAssetAtPath<SkillData>(path);
        }
    }
}
