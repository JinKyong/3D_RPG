using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;
    public Animator[] backAnimators;                 // ���� �̸��� �ҹ��ڷ�
    public Animator preferences_Btn;
    public Animator volume_Click;

    private bool isVolumeClicked = false;           // Volume_Click ���� ����

    public void OnVolume_Clicked()
    {
        if (isVolumeClicked)
        {
                                                     // Volume_Click Ʈ���Ÿ� �����Ͽ� �ִϸ��̼� ���
            volume_Click.ResetTrigger("Volume_Click");
            isVolumeClicked = false;
        }
        else
        {
            volume_Click.SetTrigger("Volume_Click");
            isVolumeClicked = true;


        }
    }

    public void Onpreferences_BtnClicked()
    {
                                                        // RunAnimation Ʈ���Ÿ� �����Ͽ� �ִϸ��̼� ���
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
            StartCoroutine(DisableAfterAnimation(animator));                   // Coroutine ���ο����� animator�� ����� �� �ֵ��� ����
        }
    }

    private IEnumerator DisableAfterAnimation(Animator animator)
    {
        yield return new WaitForSeconds(2f);                                    // �ִϸ��̼� ���� �ð� ����, �ʿ��� ��� ���� �����ϼ���

        preferencesObject.SetActive(false);

        if (isVolumeClicked)
        {
                                                                                // Volume_Click�� Ŭ���� ���¶�� �߰����� ���� ����
                                                                                // ��: �ٸ� �Լ� ȣ��, ���� ���� ��
                                                                                // ���⼭�� true�� ��ȯ�ϵ��� �����ϰڽ��ϴ�.
            isVolumeClicked = false;
                                                                                // �߰� ���� ���� �� ��ȯ
            yield return true;
        }
    }
}
