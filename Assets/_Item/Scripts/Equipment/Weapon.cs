using Item.Enum;
using Item.Data;
using UnityEngine;

namespace Item
{
    public class Weapon : Equipment
    {
        [SerializeField] WeaponData data;

        public override Sprite GetItemImage()
        {
            return data.image;
        }
        public override void Equip()
        {

        }
    }

}
