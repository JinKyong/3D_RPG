using Item.Inven;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public class DropItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] InvenItem item;
        public void OnPointerClick(PointerEventData eventData)
        {
            Inventory.Instance.AddItem(item);
            Destroy(gameObject);

            //PoolManager.Instance.Pop(transform.parent.gameObject);
            TestItemCreator.Instance.Create(Vector3.zero, Random.Range(0, 2));
        }
    }
}
