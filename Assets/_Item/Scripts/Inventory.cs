using Item.Enum;
using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Inven
{
    public class Inventory : Singleton<Inventory>
    {
        [SerializeField] InventoryUI inventoryUI;

        List<Item> equipList;
        List<Item> consumeList;
        List<Item> miscList;

        private void Start()
        {
            equipList = new List<Item>();
            consumeList = new List<Item>();
            miscList = new List<Item>();
        }

        public void AddEquipment(Item item)
        {
            equipList.Add(item);
            inventoryUI.AddItem(EItemType.Equipment, item.GetItemImage());
        }
        public void AddConsumable(Item item)
        {
            consumeList.Add(item);
            inventoryUI.AddItem(EItemType.Consumable, item.GetItemImage());
        }
        public void AddMiscellaneous(Item item)
        {
            miscList.Add(item);
            inventoryUI.AddItem(EItemType.Miscellaneous, item.GetItemImage());
        }
    }
}