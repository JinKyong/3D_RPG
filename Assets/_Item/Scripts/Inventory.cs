
using Item.Data;
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

        List<List<Item>> itemList;

        private void Start()
        {
            itemList = new List<List<Item>>(3);
            for (int i = 0; i < 3; i++)
                itemList.Add(new List<Item>());
        }

        public void AddItem(Item item)
        {
            itemList[(int)item.Data.itemType].Add(item);
            inventoryUI.AddItem(item);
        }
    }
}