using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Animator PreferencesSetting;
    [SerializeField] Animator VolumeSetting;

    private bool PreferencesBtn = false;
   

    private bool VolumeBtn = false;

    
    public void VolumeCloseOnclick()
    {
        VolumeSetting.SetBool("VolumeBtn", false);
    }

    public void PreferencesSettingOnClick()
    {
        PreferencesSetting.SetBool("PreferencesBtn", true);
    }
}