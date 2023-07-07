using Public;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Inven
{
    public class Inventory : Singleton<Inventory>
    {
        [Header("GameObject")]
        [SerializeField] Transform inventoryTR;
        List<List<Item>> itemList;

        [Space]
        [Header("UI")]
        [SerializeField] List<InventoryList> itemListUI;
        [SerializeField] ToolTip tooltip;
        int activeIndex;

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
        private int getIndexByItem(Item item, int index)
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
        private void addItemToInventory(Item item, int invenNum)
        {
            //������ �̵�(GameObject)
            itemList[invenNum].Add(item);
            item.transform.SetParent(inventoryTR);
        }
        public void AddItem(Item item)
        {
            int invenNum = (int)item.Data.itemType;
            Stackable stb = item.GetComponent<Stackable>();

            //Stackable ����
            if (stb == null)
            {
                itemListUI[invenNum].AddItem(item, itemList[invenNum].Count);
                addItemToInventory(item, invenNum);
            }
            else
            {
                int itemIndex = getIndexByItem(item, invenNum);

                //Inventory�� �̹� ���� item�� �ִ� ���(Not Full)
                if (itemIndex >= 0)
                {
                    itemListUI[invenNum].AddStackToItem(itemList[invenNum][itemIndex], itemIndex);
                    item.Remove();
                }
                //Inventory�� ���� item�� ���ų� stack�� ���� �� ���
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
            Stackable stb = itemList[invenNum][index].GetComponent<Stackable>();

            //Stackable ����
            if (stb == null)
            {
                itemListUI[invenNum].PopItem(index);
                popItemFromInventory(invenNum, index);
            }
            else
            {
                stb.Minus();
                //stack�� 0�� ��� -> �κ��丮���� ����
                if (stb.IsEmpty)
                {
                    itemListUI[invenNum].PopItem(index);
                    popItemFromInventory(invenNum, index);
                }
                //stack�� ������Ʈ
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