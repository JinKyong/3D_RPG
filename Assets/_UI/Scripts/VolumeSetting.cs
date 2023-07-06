using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSetting : MonoBehaviour
{
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void VolumeSettingClick()
    {
        bool Btn = anim.GetBool("VolumeBtn");
        anim.SetBool("VolumeBtn", !Btn);
    }
    public void VolumeSettingCloseOnclick()
    {
        anim.SetBool("VolumeBtn", false);
    }
}
