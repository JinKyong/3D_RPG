using Public;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Inven
{
    public class Inventory : Singleton<Inventory>
    {
        [Header("GameObject")]
        [SerializeField] Transform inventoryTR;
        List<List<InvenItem>> itemList;

        [Space]
        [Header("UI")]
        [SerializeField] List<InventoryList> itemListUI;
        [SerializeField] ToolTip tooltip;
        int activeIndex;

        private void Start()
        {
            itemList = new List<List<InvenItem>>(3);
            for (int i = 0; i < 3; i++)
                itemList.Add(new List<InvenItem>()); 
            
            activeIndex = itemListUI.Count - 1;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == activeIndex) itemListUI[i].SelectList();
                else itemListUI[i].UnSelectList();
            }

            //gameObject.SetActive(false);
        }
        private int getIndexByItem(InvenItem item, int index)
        {
            for (int i = 0; i < itemList[index].Count; i++)
            {
                if (itemList[index][i].Equals(item))
                {
                    Stackable stb = itemList[index][i].GetComponent<Stackable>();
                    if (!stb.IsFull)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
        private void addItemToInventory(InvenItem item, int invenNum)
        {
            //물리적 이동(GameObject)
            itemList[invenNum].Add(item);
            item.transform.SetParent(inventoryTR);
        }
        public void AddItem(InvenItem item)
        {
            int invenNum = (int)item.Data.itemType;
            Stackable stb = item.GetComponent<Stackable>();

            //Stackable 여부
            if (stb == null)
            {
                itemListUI[invenNum].AddItem(item, itemList[invenNum].Count);
                addItemToInventory(item, invenNum);
            }
            else
            {
                int itemIndex = getIndexByItem(item, invenNum);

                //Inventory에 이미 같은 item이 있는 경우(Not Full)
                if (itemIndex >= 0)
                {
                    itemListUI[invenNum].AddStackToItem(itemList[invenNum][itemIndex], itemIndex);
                    item.Remove();
                }
                //Inventory에 같은 item이 없거나 stack이 가득 찬 경우
                else
                {
                    itemListUI[invenNum].AddStackableItem(item, itemList[invenNum].Count);
                    addItemToInventory(item, invenNum);
                }
            }
        }

        private void popItemFromInventory(int invenNum, int index)
        {
            itemList[invenNum][index].Remove();
            itemList[invenNum].RemoveAt(index);
        }
        public void PopItem(int invenNum, int index)
        {
            itemList[invenNum][index].Use();
            Stackable stb = itemList[invenNum][index].GetComponent<Stackable>();

            //Stackable 여부
            if (stb == null)
            {
                itemListUI[invenNum].PopItem(index);
                popItemFromInventory(invenNum, index);
            }
            else
            {
                stb.Minus();
                //stack이 0인 경우 -> 인벤토리에서 삭제
                if (stb.IsEmpty)
                {
                    itemListUI[invenNum].PopItem(index);
                    popItemFromInventory(invenNum, index);
                }
                //stack만 업데이트
                else
                {
                    itemListUI[invenNum].PopStackFromItem(index, stb.Count);
                }
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