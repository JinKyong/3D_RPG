using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;

    private bool isVolumeClicked = false;           // Volume_Click ���� ����

    public void OnVolumeClicked()
    {

    }

    public void OnpreferencesBtnClicked()
    {

    }

    public void OnPreferencesButtonClicked()
    {

    }

    public void OnCloseButtonClicked()
    {

    }

    private IEnumerator DisableAfterAnimation(Animator animator)
    {
        yield return new WaitForSeconds(2f);                                    // �ִϸ��̼� ���� �ð� ����, �ʿ��� ��� ���� �����ϼ���

    }
}
