using Item.Interface;
using Item.Inven;

namespace Item
{
    public abstract class Equipment : Item, IEquiptable
    {
        public override void Use()
        {
            Equip();
        }
        public override void GetItem()
        {
            Inventory.Instance.AddEquipment(this);
        }

        public abstract void Equip();
    }
}
