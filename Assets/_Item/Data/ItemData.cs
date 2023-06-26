using UnityEngine;

namespace Item.Data
{
    public abstract class ItemData : ScriptableObject
    {
        [Header("Info")]
        public Sprite image;
        public string itemName;
        public string itemDesc;

        [Space]
        [Header("Cost")]
        public int buyCost;
        public int sellCost;
    }
}
