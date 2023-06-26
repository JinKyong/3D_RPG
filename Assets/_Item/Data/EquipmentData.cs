using Item.Enum;
using UnityEngine;

namespace Item.Data
{
    [CreateAssetMenu(fileName = "EquipData",
        menuName = "ScriptableObjects/Item/Equipment")]
    public class EquipmentData : ItemData
    {
        public EEquipType type;
    }
}