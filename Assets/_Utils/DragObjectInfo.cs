using Character.Ability;
using Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Drag
{
    [CreateAssetMenu(fileName ="DragObjectInfo",
        menuName ="ScriptableObjects/UI/DragObjectInfo")]
    public class DragObjectInfo : ScriptableObject
    {
        public Skill dragSkill;
        public InvenItem dragItem;
    }
}
