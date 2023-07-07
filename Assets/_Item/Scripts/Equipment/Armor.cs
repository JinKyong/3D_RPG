
using Item.Data;
using UnityEngine;

namespace Item
{
    public class Armor : Equipment
    {
        [SerializeField] ArmorData data;

        public override void Init()
        {
            Data = data;
        }
        public override void Equip()
        {

        }
    }
}
