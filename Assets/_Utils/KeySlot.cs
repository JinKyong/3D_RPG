using Character;
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

        Image img;
        public Skill SlotSkill { get; private set; }
        public InvenItem SlotItem { get; private set; }

        private void Start()
        {
            img = GetComponent<Image>();
        }

        public void FillWithSkill(Skill skill)
        {
            this.SlotSkill = skill;
            img.sprite = skill.Data.skillImage;
        }

        public void FillWithItem(InvenItem item)
        {
            this.SlotItem = item;
            img.sprite = item.Data.itemImage;
        }

        public ESlotType CanUse()
        {
            if (SlotSkill != null)
            {
                //필요 마나와 현재 마나 비교
                float mana = SlotSkill.Data.mana[SlotSkill.Level];
                if (Player.Instance.Stat.runTimeMana < mana) return ESlotType.None;
                else return ESlotType.Skill;
            }
            else if (SlotItem != null)
            {
                var stack = SlotItem.GetComponent<Stackable>();
                //스택형 아이템일 경우
                if (stack != null)
                {
                    if (stack.Count <= 0) return ESlotType.None;
                    else return ESlotType.Item;
                }
                //스택형 아이템이 아닐 경우
                else
                {
                    return ESlotType.Item;
                }
            }
            else
            {
                //아무것도 등록되어 있지 않은 경우
                return ESlotType.None;
            }
        }

        public void Use()
        {
            if (SlotSkill != null) SlotSkill.Use();
            else if (SlotItem != null) SlotItem.Use();
        }
    }
}
