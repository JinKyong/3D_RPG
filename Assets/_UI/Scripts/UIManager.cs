using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Animator PreferencesSetting;
        [SerializeField] Animator VolumeSetting;
        [SerializeField] GameObject CharChoose;


        public void OnCharChoose()
        {
            CharChoose.SetActive(true);
        }

        public void VolumeCloseOnclick()
        {
            VolumeSetting.SetBool("VolumeBtn", true);
        }

        public void PreferencesSettingOnClick()
        {
            PreferencesSetting.SetBool("PreferencesBtn", true);
        }
    }
}
