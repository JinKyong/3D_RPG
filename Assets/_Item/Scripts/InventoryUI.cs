using Item.Enum;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item.Inven
{
    public class InventoryUI : MonoBehaviour
    {
        int activeIndex;
        [SerializeField] List<GameObject> itemListUI;

        private void Start()
        {
            activeIndex = itemListUI.Count - 1;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == activeIndex) itemListUI[i].SetActive(true);
                else itemListUI[i].SetActive(false);
            }
        }

        public void OnChangeCategory(int num)
        {
            if (activeIndex == num) return;

            activeIndex = num;
            for (int i = 0; i < itemListUI.Count; i++)
            {
                if (i == num) itemListUI[i].SetActive(true);
                else itemListUI[i].SetActive(false);
            }
        }
        public void AddItem(EItemType iType, Sprite image)
        {
            InventoryInfo info = itemListUI[(int)iType].GetComponent<InventoryInfo>();
            foreach (var b in info.Contents)
            {
                if (b.interactable) continue;

                b.interactable = true;
                b.image.sprite = image;
                break;
            }
        }
    }
}
