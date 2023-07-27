using Character.Ability;
using Item;
using UnityEngine;
using UnityEngine.UI;
using Utils.Drag;

namespace UI.Slot
{
    public class KeySlot : MonoBehaviour
    {
        [SerializeField] KeySlotDTO dto;

        Button btn;
        Skill skill;
        InvenItem item;

        private void Start()
        {
            btn = GetComponent<Button>();
        }

        public void FillWithSkill(Skill skill)
        {
            this.skill = skill;
            btn.image.sprite = skill.Data.skillImage;
        }

        public void FillWithItem(InvenItem item)
        {
            this.item = item;
            btn.image.sprite = item.Data.itemImage;
        }

        public void Use()
        {
            if (skill != null) skill.Use();
            else if (item != null) item.Use();
        }
    }
}
