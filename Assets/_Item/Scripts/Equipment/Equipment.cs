using Item.Interface;
using Item.Inven;

namespace Item
{
    public abstract class Equipment : InvenItem, IEquiptable
    {
        public override void Use()
        {
            Equip();
        }

        public abstract void Equip();
    }
}
