using Item.Enum;
using Item.Data;
using UnityEngine;
using Character;

namespace Item
{
    public class Potion : Consumable
    {
        [SerializeField] PotionData data;

        public override void Init()
        {
            Data = data;
        }
        public override void Consume()
        {
            float value = data.value;
            Debug.Log(data.itemName + " »ç¿ë(¼·Ãë)");

            switch (data.type)
            {
                case EPotionType.Health:
                    Player.Instance.ControlStat(value, 0);
                    break;
                case EPotionType.Mana:
                    Player.Instance.ControlStat(0, value);
                    break;
                default:
                    break;
            }
        }
    }
}

