using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;
    public Animator[] backAnimators; // ���� �̸��� �ҹ��ڷ� �����ϵ��� ����
    public Animator preferences_Btn;


    public void Onpreferences_BtnClicked()
    {
        preferences_Btn.SetTrigger("RunAnimation");
    
    }


    public void OnPreferencesButtonClicked()
    {
        preferencesObject.SetActive(true);
    }

    public void OnCloseButtonClicked()
    {
        foreach (Animator animator in backAnimators)
        {
            animator.SetTrigger("Close");
            StartCoroutine(DisableAfterAnimation(animator)); // Coroutine ���ο����� animator�� ����� �� �ֵ��� ����
        }
    }

    private IEnumerator DisableAfterAnimation(Animator animator) // IEnumerator�� Animator �Ķ���� �߰�
    {
        yield return new WaitForSeconds(2f); // �ִϸ��̼� ���� �ð� ����, �ʿ��� ��� ���� �����ϼ���

        preferencesObject.SetActive(false);
    }
}
