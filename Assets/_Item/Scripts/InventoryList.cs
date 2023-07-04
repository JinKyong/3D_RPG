using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Item.Inven
{
    public class InventoryList : MonoBehaviour
    {
        public List<Button> Contents { get; private set; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        [SerializeField] Transform contentTR;

        private void Awake()
        {
            Count = 0;
            Capacity = contentTR.childCount;
            Contents = new List<Button>();
            for (int i = 0; i < Capacity; i++)
            {
                Button btn = contentTR.GetChild(i).GetComponent<Button>();
                int index = i;
                btn.onClick.AddListener(() =>
               {
                   PopItem(index);
               });
                Contents.Add(btn);
            }
        }

        public void AddItem(Item item, int index)
        {
            Contents[index].interactable = true;
            Contents[index].image.sprite = item.Data.image;
        }
        public void PopItem(int index)
        {
            Contents[index].interactable = false;
            Contents[index].image.sprite = null;
            Contents[index].transform.SetAsLastSibling();
            //앞으로 떙기기
        }
    }
}
