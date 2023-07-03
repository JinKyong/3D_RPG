using Item.Enum;
using Item.Data;
using UnityEngine;

namespace Item
{
    public class Potion : Consumable
    {
        [SerializeField] PotionData data;

        public override Sprite GetItemImage()
        {
            return data.image;
        }
        public override void Consume()
        {
            float value = data.value;
            Debug.Log(data.itemName + " ���(����)");

            switch (data.type)
            {
                case EPotionType.Health:
                    break;
                case EPotionType.Mana:
                    break;
                default:
                    break;
            }
        }
    }
}

