using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Animator PreferencesSetting;
    [SerializeField] Animator VolumeSetting;



    
    public void VolumeCloseOnclick()
    {   
        VolumeSetting.SetBool("VolumeBtn", true);
    }

    public void PreferencesSettingOnClick()
    {
        PreferencesSetting.SetBool("PreferencesBtn", true);
    }
}