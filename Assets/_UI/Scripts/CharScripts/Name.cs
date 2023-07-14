using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Name
{
    public class Name : MonoBehaviour
    {
        [SerializeField] GameObject nickNameBar;
        [SerializeField] GameObject playerGameObj;
        [SerializeField] GameObject playerInfoObj;
        [SerializeField] GameObject testObj;

        [SerializeField] TMP_InputField nicknameInput;
        [SerializeField] TMP_Text notify;
        [SerializeField] TMP_Text nickNameText;
        

        private void Start()
        {
            notify.text = "";
        }

        private void OnMouseDown()
        {
            
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
                nickNameText.text = nickname; // 닉네임 표시
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
            {
                CheckButton();
            }
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

        private void CheckButton()
        {
            testObj.SetActive(true);
            playerGameObj.SetActive(true);
            nickNameBar.SetActive(false);
            playerInfoObj.SetActive(true);

        }


    }
}
