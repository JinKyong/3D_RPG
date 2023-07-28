using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VolumeSetting
{ 
    public class VolumeSetting : MonoBehaviour
    {
        Animator anim;


        void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void SetBackClick(bool setBack)
        {
            setBack = anim.GetBool("SetBack");
            anim.SetBool("SetBack", !setBack);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SetBack"))
            {
                anim.SetBool("VolumeBtn", true);
                anim.SetBool("SetBack", false);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool("VolumeBtn", false);
                anim.SetBool("SetBack", false);
            }
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
}