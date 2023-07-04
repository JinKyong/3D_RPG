using Public;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Inven
{
    public class Inventory : Singleton<Inventory>
    {
        List<List<Item>> itemList;

        //UI
        int activeIndex;
        [SerializeField] List<InventoryList> itemListUI;

        private void Start()
        {
            itemList = new List<List<Item>>(3);
            for (int i = 0; i < 3; i++)
                itemList.Add(new List<Item>()); 
            
            activeIndex = itemListUI.Count - 1;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == activeIndex) itemListUI[i].gameObject.SetActive(true);
                else itemListUI[i].gameObject.SetActive(false);
            }
        }

        public void AddItem(Item item)
        {
            int index = (int)item.Data.itemType;

            itemListUI[index].AddItem(item, itemList[index].Count);
            itemList[index].Add(item);
        }
        public void OnChangeCategory(int num)
        {
            if (activeIndex == num) return;

            activeIndex = num;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == num) itemListUI[i].gameObject.SetActive(true);
                else itemListUI[i].gameObject.SetActive(false);
            }
        }
    }
}