using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField id;        // ���� ���̵� ����.

    public InputField password; // ���� �н����� ����.

    public Text notify;         // �ߺ��� �ִ��� �˻�.

    private void Start()
    {
        notify.text = "";       // �˻� �ؽ�Ʈ â�� ����ش�.
    }

    public void SaveUserData()                                  // ���̵�� �н����� �� ���� �ϴ� �Լ�.
    {
        if (!CheckInput(id.text, password.text))                // ���� �Է� �˻翡 ������ ������ �Լ��� ����.
            return;
        {
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
    }
    public void CheckUserData()                            // �α��� �� ���� Ȯ���� �ʿ���� �Լ�.
    {
        if (CheckInput(id.text, password.text))            // ���� �Է� �˻翡 ������ ������ �Լ��� ����. 
            return;
        {
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
    }
    bool CheckInput(string id, string pwd)                      // �Է� �Ϸ� Ȯ�� �Լ�
    {
        if (id == "" || pwd == "")                              // ����, �Է¶��� �ϳ��� ��� ������ ���� ���� �Է��� �䱸�Ѵ�.
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
    