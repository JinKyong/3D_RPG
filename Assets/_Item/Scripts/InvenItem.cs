using Item.Data;
using Item.Inven;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Public;

namespace Item
{
    public abstract class InvenItem : MonoBehaviour
    {
        public ItemData Data { get; protected set; }

        private void Start()
        {
            Init();
        }

        public abstract void Init();
        public abstract void Use();

        public void Remove()
        {
            PoolManager.Instance.Push(gameObject);
        }

        public override bool Equals(object other)
        {
            InvenItem otherItem = (InvenItem)other;

            return (Data.itemType == otherItem.Data.itemType) &&
                (Data.itemNumber == otherItem.Data.itemNumber);
        }
    }
}
