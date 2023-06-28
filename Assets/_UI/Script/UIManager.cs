using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;

    public void OnPreferencesButtonClicked()
    {
        preferencesObject.SetActive(true);
    }
}

