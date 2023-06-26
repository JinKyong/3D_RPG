using Item.Enum;
using UnityEngine;

namespace Item
{
    public class Potion : Consumable
    {
        public override void Consume()
        {
            float value = data.value;
            Debug.Log(data.itemName + " »ç¿ë(¼·Ãë)");
        }
    }
}

