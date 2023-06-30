using Item.Interface;

namespace Item
{
    public abstract class Equipment : Item, IEquiptable
    {
        public override void Use()
        {
            Equip();
        }

        public abstract void Equip();
    }
}
