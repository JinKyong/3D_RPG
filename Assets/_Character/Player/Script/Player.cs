using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using Character.State;
using UnityEngine.UI;
using TMPro;
using UI.Slot;
using Character.Ability;

namespace Character
{
    public class Player : Singleton<Player>
    {
        [Header("UI")]
        [SerializeField] Canvas skillUI;
        [SerializeField] GameObject dragObject;
        [SerializeField] GameObject inventory;

        [Header("Stat")]
        [Space]
        [SerializeField] PlayerStat playerStat;
        [SerializeField] KeySlot[] slots;

        public Slider hpSlider;
        public Slider mpSlider;
        [SerializeField] TMP_Text HpText;
        [SerializeField] TMP_Text MpText;

        public PlayerStat Stat { get { return playerStat; } }

        [SerializeField] PlayerController playerController;

        private void Start()
        {
            hpSlider.value = Stat.runTimeHealth / Stat.runTimeMaxHealth;
            mpSlider.value = Stat.runTimeMana / Stat.runTimeMaxMana;

            HpText.text = $"Hp : {Stat.runTimeHealth} / {Stat.runTimeMaxHealth}";
            MpText.text = $"Mp : {Stat.runTimeMana} / {Stat.runTimeMaxMana}";
        }

        private void Update()
        {
            controlKey();
        }

        public void ControlStat(float health, float mana)
        {
            Stat.runTimeHealth += health;
            Stat.runTimeMana += mana;
            Stat.runTimeHealth = Mathf.Clamp(Stat.runTimeHealth, 0, Stat.runTimeMaxHealth);
            Stat.runTimeMana = Mathf.Clamp(Stat.runTimeMana, 0, Stat.runTimeMaxMana);

            hpSlider.value = Stat.runTimeHealth / Stat.runTimeMaxHealth;
            mpSlider.value = Stat.runTimeMana / Stat.runTimeMaxMana;

            HpText.text = $"Hp : {Stat.runTimeHealth} / {Stat.runTimeMaxHealth}";
            MpText.text = $"Mp : {Stat.runTimeMana} / {Stat.runTimeMaxMana}";
        }

        private void controlKey()
        {
            if (!playerController.OnSkill)
            {

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    UseSlot(0);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    UseSlot(1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    UseSlot(2);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    UseSlot(3);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    UseSlot(4);
                }
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                skillUI.gameObject.SetActive(true);
                dragObject.SetActive(true);
            }
        }
        // 인터페이스 창을 열 수 있도록 하는 내용들
        public void UseSlot(int index)
        {
            switch (slots[index].CanUse())
            {
                case ESlotType.Skill:
                    Skill skill = slots[index].SlotSkill;
                    //스킬사용
                    playerController.skillClip = skill.Data.animClip;
                    playerController.OnSkill = true;
                    Player.Instance.ControlStat(0, -skill.Data.mana[skill.Level]);
                    slots[index].Use();
                    break;
                case ESlotType.Item:
                    //아이템사용
                    slots[index].Use();
                    break;
                case ESlotType.None:
                    break;
            }
        }
    }

}