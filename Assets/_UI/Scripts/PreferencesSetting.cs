using UnityEngine;

namespace PreferencesSetting
{ 
    public class PreferencesSetting : MonoBehaviour
    {
        Animator anim;
        private void Start()
        {
            anim = GetComponent<Animator>();
            // �߰�: PreferencesSetting ���� ������Ʈ Ȱ��ȭ
            gameObject.SetActive(true);
        }
        public void PreferencesSettingClick()
        {
            bool btn = anim.GetBool("PreferencesBtn");
            anim.SetBool("PreferencesBtn", !btn);
        }
        public void PreferencesSideOnclick()
        {
            bool sideBtn = anim.GetBool("Side");
            anim.SetBool("Side", !sideBtn);
        }
        public void PreferencesSideBackOnclick()
        {
            bool sideBackBtn = anim.GetBool("SideBack");
            anim.SetBool("SideBack", !sideBackBtn);
        }
    }

}