using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item.Inven
{
    public class ToolTip : MonoBehaviour
    {
        [SerializeField] Image itemImage;
        [SerializeField] Text itemDesc;

        int listNum;
        int itemNum;

        public void Init(InvenItem item, int listNum, int itemNum)
        {
            itemImage.sprite = item.Data.itemImage;
            itemDesc.text = item.Data.itemDesc;

            this.listNum = listNum;
            this.itemNum = itemNum;
        }

        public void Use()
        {
            Inventory.Instance.PopItem(listNum, itemNum);
        }
    }
}
