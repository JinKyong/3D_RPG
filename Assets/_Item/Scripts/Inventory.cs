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
        [SerializeField] ToolTip tooltip;

        private void Start()
        {
            itemList = new List<List<Item>>(3);
            for (int i = 0; i < 3; i++)
                itemList.Add(new List<Item>()); 
            
            activeIndex = itemListUI.Count - 1;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == activeIndex) itemListUI[i].SelectList();
                else itemListUI[i].UnSelectList();
            }
        }

        public void AddItem(Item item)
        {
            int index = (int)item.Data.itemType;
            Stackable stb = item.GetComponent<Stackable>();

            //Stackable 여부
            if (stb == null)
            {
                itemListUI[index].AddItem(item, itemList[index].Count);
                itemList[index].Add(item);
            }
            else
            {
                //인벤토리 서치(이미 있는 아이템인지)

            }
        }
        public void PopItem(int invenNum, int index)
        {
            Stackable stb = itemList[invenNum][index].GetComponent<Stackable>();

            //Stackable 여부
            if (stb == null)
            {
                itemListUI[invenNum].PopItem(index);
                itemList[invenNum].RemoveAt(index);
            }
            else
            {
                
            }
        }

        public void OnTooltip(int listNum, int itemNum)
        {
            tooltip.Init(itemList[listNum][itemNum], listNum, itemNum);
            tooltip.gameObject.SetActive(true);
        }

        public void OnChangeCategory(int num)
        {
            if (activeIndex == num) return;

            activeIndex = num;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == activeIndex) itemListUI[i].SelectList();
                else itemListUI[i].UnSelectList();
            }
        }
        public void OnExitInventory()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}