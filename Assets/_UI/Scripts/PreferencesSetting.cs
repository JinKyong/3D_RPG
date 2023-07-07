using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // �߰�: Back ������ �� �Ķ���� �ʱ�ȭ
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

        // �߰�: Back ������ �� �Ķ���� �ʱ�ȭ
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

        // �߰�: Back ������ �� �Ķ���� �ʱ�ȭ
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Back"))
        {
            anim.SetBool("PreferencesBtn", false);
            anim.SetBool("Side", false);
        }
    }

    public void ResetParameters()
    {
        // �߰�: ��� �Ķ���� �ʱ�ȭ
        anim.SetBool("PreferencesBtn", false);
        anim.SetBool("Side", false);
        anim.SetBool("SideBack", false);
    }
}
