using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace Character.Ability.Data
{
    [CreateAssetMenu(fileName = "SkillDTO",
        menuName = "ScriptableObjects/DTO/Skill")]
    public class SkillDTO : DataTransferObject<Skill>
    {

    }
}