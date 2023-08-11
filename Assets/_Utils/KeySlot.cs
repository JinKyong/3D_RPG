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
                //�ʿ� ������ ���� ���� ��
                float mana = SlotSkill.Data.mana[SlotSkill.Level];
                if (Player.Instance.Stat.runTimeMana < mana) return ESlotType.None;
                else return ESlotType.Skill;
            }
            else if (SlotItem != null)
            {
                var stack = SlotItem.GetComponent<Stackable>();
                //������ �������� ���
                if (stack != null)
                {
                    if (stack.Count <= 0) return ESlotType.None;
                    else return ESlotType.Item;
                }
                //������ �������� �ƴ� ���
                else
                {
                    return ESlotType.Item;
                }
            }
            else
            {
                //�ƹ��͵� ��ϵǾ� ���� ���� ���
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
