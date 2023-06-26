using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Data
{
    [CreateAssetMenu(fileName = "ConsumableData",
           menuName = "ScriptableObjects/Item/Consumable")]
    public class ConsumableData : ItemData
    {
        public float duration;
        public float value;
    }
}
