using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item.Inven
{
    public class ItemBox : MonoBehaviour
    {
        [Header("Outer")]
        [SerializeField] Transform parentTR;

        [Space]
        [Header("Component")]
        [SerializeField] Button box;
        [SerializeField] Image back;
        [SerializeField] Image front;
        [SerializeField] Text count;

        public void FillBoxWithItem(Item item)
        {
            box.interactable = true;
            back.enabled = true;
            front.enabled = true;
            front.sprite = item.Data.image;
        }
        public void FillBoxWithStackableItem(Item item, int num)
        {
            FillBoxWithItem(item);

            count.enabled = true;
            count.text = num.ToString();
        }
        public void UpdateCount(int num)
        {
            count.text = num.ToString();
        }
        public void ClearBox()
        {
            box.interactable = false;
            back.enabled = false;
            front.enabled = false;
            count.enabled = false;
            
            box.transform.SetAsLastSibling();
        }

        public void OnClick()
        {
            //������ ����
            Inventory.Instance.OnTooltip(
                parentTR.GetSiblingIndex(),
                transform.GetSiblingIndex()
                );
        }
    }
}
