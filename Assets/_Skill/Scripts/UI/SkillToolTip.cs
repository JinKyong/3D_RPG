using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Character.Ability.Data;
using Utils.Drag;

namespace Character.Ability.UI
{
    public class SkillToolTip : MonoBehaviour
    {
        [SerializeField] SkillDTO dto;
        [SerializeField] SkillDragObject dragIcon;

        [Header("Component")]
        [Space]
        [SerializeField] Image icon;
        [SerializeField] TMP_Text skillName;
        [SerializeField] TMP_Text skillLevel;
        [SerializeField] TMP_Text skillDesc;

        public void FillWithSkill()
        {
            Skill skill = dto.data;
            dragIcon.transform.position = icon.transform.position;
            dragIcon.SetImage(skill.Data.skillImage);

            icon.sprite = skill.Data.skillImage;
            skillName.text = skill.Data.skillName;
            skillLevel.text = skill.Level.ToString();
            skillDesc.text = skill.GetDesc();
        }
    }
}