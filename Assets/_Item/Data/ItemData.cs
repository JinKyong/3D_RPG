using Item.Enum;
using System.Collections.Generic;

using UnityEngine;

namespace Item.Data
{
    public abstract class ItemData : ScriptableObject
    {
        [Header("Info")]
        public Sprite itemImage;
        public EItemType itemType;
        public int itemNumber;
        public string itemName;
        public string itemDesc;

        [Space]
        [Header("Stat")]
        public int buyCost;
        public int sellCost;
        public bool bStackable;
        public int maxStack;
    }
}
