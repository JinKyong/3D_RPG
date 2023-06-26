using Item.Data;
using UnityEngine;

namespace Item
{
    public abstract class Equipment : Item
    {
        [SerializeField] EquipmentData data;
    }
}
