
using Item.Interface;
using Item.Inven;

namespace Item
{
    public abstract class Consumable : Item, IConsumable
    {
        public override void Use()
        {
            Consume();
        }
        public override void GetItem()
        {
            Inventory.Instance.AddConsumable(this);
        }
        public abstract void Consume();
    }
}
