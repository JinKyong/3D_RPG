using Item.Enum;
using UnityEngine;

namespace Item.Data
{
    [CreateAssetMenu(fileName = "WeaponData",
        menuName = "ScriptableObjects/Item/Equipment/Weapon")]
    public class WeaponData : ItemData
    {
        [Space]
        [Header("Weapont Value")]
        public EWeaponType type;
    }
}