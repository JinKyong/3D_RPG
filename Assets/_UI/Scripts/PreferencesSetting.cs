using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesSetting : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void VolumeSettingOnClick()
    {
        anim.SetBool("PreferencesBtn", true);
    }
    public void VolumeCloseOnclick()
    {
        anim.SetBool("PreferencesBtn", false);
    }
}
