
using Item.Data;
using UnityEngine;

namespace Item
{
    public class Armor : Equipment
    {
        [SerializeField] ArmorData data;

        public override Sprite GetItemImage()
        {
            return data.image;
        }
        public override void Equip()
        {

        }
    }
}
