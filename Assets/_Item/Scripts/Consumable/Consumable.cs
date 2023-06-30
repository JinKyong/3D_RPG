using Item.Data;
using Item.Interface;

namespace Item
{
    public abstract class Consumable : Item, IConsumable
    {
        public override void Use()
        {
            Consume();
        }
        public abstract void Consume();
    }
}
