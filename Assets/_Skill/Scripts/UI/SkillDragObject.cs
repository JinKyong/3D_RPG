using Character.Ability.Data;
using UI.Slot;
using UnityEngine;
using UnityEngine.UI;
using Utils.Drag;

namespace Character.Ability.UI
{
    public class SkillDragObject : MonoBehaviour
    {
        [SerializeField] SkillDTO skillDTO;
        [SerializeField] DragObjectInfo info;
        public GameObject target;
        Image img;

        private void Start()
        {
            img = GetComponent<Image>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("KeySlot"))
            {
                target = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("KeySlot"))
            {
                target = null;
            }
        }

        public void SetImage(Sprite sprite)
        {
            img.sprite = sprite;
        }

        public void SetInfoWithSKill()
        {
            info.dragSkill = skillDTO.data;
        }
        public void SetSlotWithSkill()
        {
            if (target == null) return;

            //Ã¤¿ì±â
            target.GetComponent<KeySlot>().FillWithSkill(skillDTO.data);
        }
        public void ResetInfo()
        {
            info.dragSkill = null;
        }
    }
}
