using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public abstract class Item : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Pointer Click");
            GetItem();
        }

        public abstract void Use();
        public abstract void GetItem();
        public abstract Sprite GetItemImage();
    }
}
