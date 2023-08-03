using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Item.Inven
{
    public class InventoryList : MonoBehaviour
    {
        private static class ButtonColor
        {
            public static Color Select = new Color(1f, 1f, 1f, 1f);
            public static Color UnSelect = new Color(1f, 1f, 1f, 0.5f);
        }

        int invenNum;
        [SerializeField] Button categoryBtn;
        [SerializeField] Transform contentTR;

        public void SelectList()
        {
            gameObject.SetActive(true);
            categoryBtn.image.color = ButtonColor.Select;
        }
        public void UnSelectList()
        {
            gameObject.SetActive(false);
            categoryBtn.image.color = ButtonColor.UnSelect;
        }

        public void AddItem(Item item, int index)
        {
            ItemBox box = contentTR.GetChild(index).GetComponent<ItemBox>();

            box.FillBoxWithItem(item);
        }
        public void AddStackableItem(Item item, int index)
        {
            Stackable stb = item.GetComponent<Stackable>();
            ItemBox box = contentTR.GetChild(index).GetComponent<ItemBox>();

            stb.Plus();
            box.FillBoxWithStackableItem(item, stb.Count);
        }
        public void AddStackToItem(Item item, int index)
        {
            Stackable stb = item.GetComponent<Stackable>();
            ItemBox box = contentTR.GetChild(index).GetComponent<ItemBox>();

            stb.Plus();
            box.UpdateCount(stb.Count);
        }


        public void PopItem(int index)
        {
            ItemBox box = contentTR.GetChild(index).GetComponent<ItemBox>();

            box.ClearBox();
        }
        public void PopStackFromItem(int index, int count)
        {
            ItemBox box = contentTR.GetChild(index).GetComponent<ItemBox>();

            box.UpdateCount(count);
        }
    }
}
