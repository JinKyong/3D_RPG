using System.Collections;
using System.Collections.Generic;
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

        // 추가: Back 상태일 때 파라미터 초기화
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Back"))
        {
            anim.SetBool("Side", false);
            anim.SetBool("SideBack", false);
        }

      
    }

    public void PreferencesSideOnclick()
    {
        bool sideBtn = anim.GetBool("Side");

        anim.SetBool("Side", !sideBtn);

        // 추가: Back 상태일 때 파라미터 초기화
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Back"))
        {
            anim.SetBool("PreferencesBtn", false);
            anim.SetBool("SideBack", false);
        }
    }

    public void PreferencesSideBackOnclick()
    {
        bool sideBackBtn = anim.GetBool("SideBack");

        anim.SetBool("SideBack", !sideBackBtn);

        // 추가: Back 상태일 때 파라미터 초기화
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Back"))
        {
            anim.SetBool("PreferencesBtn", false);
            anim.SetBool("Side", false);
        }
    }

    public void ResetParameters()
    {
        // 추가: 모든 파라미터 초기화
        anim.SetBool("PreferencesBtn", false);
        anim.SetBool("Side", false);
        anim.SetBool("SideBack", false);
    }
}
