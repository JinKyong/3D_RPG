using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;

    private bool isVolumeClicked = false;           // Volume_Click 상태 변수

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
        yield return new WaitForSeconds(2f);                                    // 애니메이션 실행 시간 조절, 필요한 경우 값을 변경하세요

    }
}
