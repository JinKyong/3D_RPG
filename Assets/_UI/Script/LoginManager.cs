using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Main.UI
{
    public class LoginManager : MonoBehaviour
    {
        [SerializeField] InputField id;        // ���� ���̵� ����.

        [SerializeField] InputField password; // ���� �н����� ����.

        [SerializeField] Text notify;         // �ߺ��� �ִ��� �˻�.

        private void Start()
        {
            notify.text = "";       // �˻� �ؽ�Ʈ â�� ����ش�.
        }

        public void SaveUserData()                                  // ���̵�� �н����� �� ���� �ϴ� �Լ�.
        {
            if (!CheckInput())     // ���� �Է� �˻翡 ������ ������ �Լ��� ����.
                return;

            if (!PlayerPrefs.HasKey(id.text))                   // �ý��ۿ� ����� �ִ� ���̵� �������� �ʴ´ٸ�...
            {
                PlayerPrefs.SetString(id.text, password.text);  // ������� ���̵� Ű �� �н����带 ��(value)���� �����Ͽ� ����.
                PlayerPrefs.Save();                             // ������� ������ �����Ѵ�.
                notify.text = "���̵� ������ �Ϸ�ƽ��ϴ�.!";
            }
            else                                                // �׷��� ������, �̹� �����Ѵٴ� �޽����� �����.
            {
                notify.text = "�̹� �����ϴ� ���̵��Դϴ�.!";
            }


        }
        public void CheckUserData()                            // �α��� �� ���� Ȯ���� �ʿ���� �Լ�.
        {
            if (CheckInput())            // ���� �Է� �˻翡 ������ ������ �Լ��� ����. 
                return;
            string pass = PlayerPrefs.GetString(id.text);   //  ����ڰ� �Է��� ���̵� Ű�� ����� �ý��ۿ� ����� ���� �ҷ��´�.

            if (password.text == pass)                      // ����, ����ڰ� �Է��� �н������ �ý��ۿ��� �ҷ��� ������ ���ؼ� �����ϴٸ�!
            {
                SceneManager.LoadScene("");                 // ���� �� "" �� �ε��Ѵ�.
            }
            else
            {
                notify.text = "�Ϸ��Ͻ� ���̵�� �н����尡 ��ġ���� �ʽ��ϴ�.!";    // �׷��� �ʰ� �� ������ ���� �ٸ��� , ���� ������ ��ġ���� �ʾ� �޽����� ����.
            }

        }
        bool CheckInput()                      // �Է� �Ϸ� Ȯ�� �Լ�
        {
            if (id.text == "" || password.text == "")                              // ����, �Է¶��� �ϳ��� ��� ������ ���� ���� �Է��� �䱸�Ѵ�.
            {
                notify.text = "���̵� �Ǵ� �н����带 �Է����ּ���";
                return false;
            }
            // �Է��� ��� ���� ������ ture�� ��ȯ�Ѵ�.
            else
            {
                return true;
            }

        }
    }
}

    