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

        Button btn;
        Image img;
        Skill skill;
        InvenItem item;

        private void Start()
        {
            btn = GetComponent<Button>();
            img = GetComponent<Image>();
        }

        public void FillWithSkill(Skill skill)
        {
            this.skill = skill;
            //btn.image.sprite = skill.Data.skillImage;
            Debug.Log(img);
            Debug.Log(skill);
            img.sprite = skill.Data.skillImage;
        }

        public void FillWithItem(InvenItem item)
        {
            this.item = item;
            //btn.image.sprite = item.Data.itemImage;
            img.sprite = item.Data.itemImage;
        }

        public ESlotType CanUse()
        {
            if (skill != null)
            {
                //필요 마나와 현재 마나 비교
                float mana = skill.Data.mana[skill.Level];
                if (Player.Instance.Stat.runTimeMana < mana) return ESlotType.None;
                else return ESlotType.Skill;
            }
            else if (item != null)
            {
                var stack = item.GetComponent<Stackable>();
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
            if (skill != null) skill.Use();
            else if (item != null) item.Use();
        }
    }
}
