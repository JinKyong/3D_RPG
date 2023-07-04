using Item.Data;
using Item.Inven;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public abstract class Item : MonoBehaviour, IPointerClickHandler
    {
        public ItemData Data { get; protected set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            Inventory.Instance.AddItem(this);
        }

        private void Start()
        {
            Init();
        }

        public abstract void Init();
        public abstract void Use();
    }
}
