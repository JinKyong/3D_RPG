using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Character.Ability.Data;
using Public;

namespace Character.Ability.UI
{
    public class SkillBox : MonoBehaviour
    {
        Skill skill;
        [SerializeField] GameEvent clickEvent;
        [SerializeField] SkillDTO dto;

        [Header("Component")]
        [SerializeField] Button box;
        [SerializeField] Image skillImage;
        [SerializeField] TMP_Text nameTMP;
        [SerializeField] TMP_Text levelTMP;

        public void FillBoxWithSkill(Skill skill, int level)
        {
            this.skill = skill;

            skillImage.sprite = skill.Data.skillImage;
            nameTMP.text = skill.Data.skillName;
            levelTMP.text = level.ToString();
        }
        public void UpdateLevel(int level)
        {
            levelTMP.text = level.ToString();
        }
        public void Clear()
        {
            levelTMP.text = "0";
        }

        public void OnClick()
        {
            dto.data = skill;
            clickEvent.Raise();
        }
    }
}
