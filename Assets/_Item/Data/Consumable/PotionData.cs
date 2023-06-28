using Item.Enum;
using UnityEngine;

namespace Item.Data
{
    [CreateAssetMenu(fileName = "PotionData",
           menuName = "ScriptableObjects/Item/Consumable/Potion")]
    public class PotionData : ItemData
    {
        [Space]
        [Header("Potion Value")]
        public EPotionType type;
        public float duration;
        public float value;
    }
}
