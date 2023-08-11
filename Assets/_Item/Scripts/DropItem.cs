using Item.Inven;
using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] InvenItem item;
        public void GetItem()
        {
            Inventory.Instance.AddItem(item);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetItem();
            }
        }
    }
}
