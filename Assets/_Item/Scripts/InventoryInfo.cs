using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Item.Inven
{
    public class InventoryInfo : MonoBehaviour
    {
        public List<Button> Contents { get; private set; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        [SerializeField] Transform contentTR;

        private void Start()
        {
            Count = 0;
            Capacity = transform.childCount;
            Contents = new List<Button>();
            foreach (Transform t in contentTR)
                Contents.Add(t.GetComponent<Button>());
        }

        public void AddItem()
        {
            Count++;
        }
        public void PopItem()
        {
            Count--;
        }
    }
}
