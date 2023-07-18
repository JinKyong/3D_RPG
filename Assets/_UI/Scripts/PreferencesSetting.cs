using UnityEngine;
public class PreferencesSetting : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        // 추가: PreferencesSetting 게임 오브젝트 활성화
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
