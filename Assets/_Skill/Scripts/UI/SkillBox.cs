using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Character.Ability.Data;

namespace Character.Ability.UI
{
    public class SkillBox : MonoBehaviour
    {
        [Header("Component")]
        [SerializeField] Button box;
        [SerializeField] Image skillImage;
        [SerializeField] TMP_Text nameTMP;
        [SerializeField] TMP_Text levelTMP;

        public void FillBoxWithSkill(SkillData data, int level)
        {
            skillImage.sprite = data.skillImage;
            nameTMP.text = data.skillName;
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

        }
    }
}
