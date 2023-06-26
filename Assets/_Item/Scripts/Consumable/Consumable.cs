using Item.Data;
using Item.Interface;
using UnityEngine;

namespace Item
{
    public abstract class Consumable : Item, IConsumable
    {
        [SerializeField] protected ConsumableData data;

        public override void Use()
        {
            Consume();
        }
        public abstract void Consume();
    }
}
