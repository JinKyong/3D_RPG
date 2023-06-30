using Item.Enum;
using UnityEngine;

namespace Item.Data
{
    [CreateAssetMenu(fileName = "ArmorData",
        menuName = "ScriptableObjects/Item/Equipment/Armor")]
    public class ArmorData : ItemData
    {
        [Space]
        [Header("Armor Value")]
        public EArmorType type;
    }
}