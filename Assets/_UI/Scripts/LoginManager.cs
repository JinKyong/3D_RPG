using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Main.UI
{
    public class LoginManager : MonoBehaviour
    {
        [SerializeField] InputField id;        // 유저 아이디 변수.

        [SerializeField] InputField password; // 유저 패스워드 변수.

        [SerializeField] Text notify;         // 중복이 있는지 검사.

        private void Start()
        {
            notify.text = "";       // 검사 텍스트 창을 비워준다.
        }

        public void SaveUserData()                                  // 아이디와 패스워드 를 저장 하는 함수.
        {
            if (!CheckInput())                                          // 만일 입력 검사에 문제가 있을시 함수를 종료.
                return;

            if (!PlayerPrefs.HasKey(id.text))                   // 시스템에 저장돼 있는 아이디가 존재하지 않는다면...
            {
                PlayerPrefs.SetString(id.text, password.text);  // 사용자의 아이디 키 로 패스워드를 값(value)으로 설정하여 저장.
                PlayerPrefs.Save();                             // 사용자의 정보를 저장한다.
                notify.text = "아이디 생성이 완료됐습니다.!";
            }
            else                                                // 그렇지 않으면, 이미 존재한다는 메시지를 출력함.
            {
                notify.text = "이미 존재하는 아이디입니다.!";
            }


        }
        public void CheckUserData()                                   // 로그인 을 위해 확인을 필요로한 함수.
        {
            Debug.Log("1");
            if (!CheckInput())                                          // 만일 입력 검사에 문제가 있으면 함수를 종료. 
                return;
            string pass = PlayerPrefs.GetString(id.text);           //  사용자가 입력한 아이디를 키로 사용해 시스템에 저장된 값을 불러온다.

            if (password.text == pass)                                   // 만일, 사용자가 입력한 패스워드와 시스템에서 불러오 ㄴ값을 비교해서 동일하다면!
            {
                SceneManager.LoadScene("CharacterSceneStatus");                 // 다음 씬 "" 을 로드한다.
                Debug.Log("2");
            }
            else
            {
                notify.text = "일력하신 아이디와 패스워드가 일치하지 않습니다.!";    // 그렇지 않고 두 데이터 값이 다르면 , 유저 정보가 일치하지 않아 메시지를 남김.
                Debug.Log("3");
            }

        }
        bool CheckInput()                                               // 입력 완료 확인 함수
        {
            if (id.text == "" || password.text == "")                              // 만일, 입력란이 하나라도 비어 있으면 유저 정보 입력을 요구한다.
            {
                notify.text = "아이디 또는 패스워드를 입력해주세요";
                return false;
            }
                                                                         // 입력이 비어 있지 않으면 ture를 반환한다.
            else
            {
                return true;
            }

        }
    }
}

    