using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Name : MonoBehaviour
{
    [SerializeField] TMP_InputField nicknameInput;
    [SerializeField] TMP_Text notify;

    private void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        string nickname = nicknameInput.text;

        if (!CheckInput(nickname))
            return;

        if (!PlayerPrefs.HasKey(nickname))
        {
            PlayerPrefs.SetString(nickname, "");
            PlayerPrefs.Save();
            notify.text = "OK"; 
        }
        else
        {
            notify.text = "NO.";
        }
    }

    public void CheckUserData()
    {
        string nickname = nicknameInput.text;

        if (!CheckInput(nickname))
            return;

        if (PlayerPrefs.HasKey(nickname))
        { }
        else
            notify.text = "Check OK.";
    }

    bool CheckInput(string nickname)
    {
        if (nickname == "")
        {
            notify.text = "Name Plz.";
            return false;
        }
        else
        {
            return true;
        }
    }
}
