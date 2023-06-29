using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;
    public Animator[] backAnimators;                 // 변수 이름을 소문자로
    public Animator preferences_Btn;
    public Animator volume_Click;

    private bool isVolumeClicked = false;           // Volume_Click 상태 변수

    public void OnVolume_Clicked()
    {
        if (isVolumeClicked)
        {
                                                     // Volume_Click 트리거를 실행하여 애니메이션 재생
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
                                                        // RunAnimation 트리거를 실행하여 애니메이션 재생
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
            StartCoroutine(DisableAfterAnimation(animator));                   // Coroutine 내부에서도 animator를 사용할 수 있도록 수정
        }
    }

    private IEnumerator DisableAfterAnimation(Animator animator)
    {
        yield return new WaitForSeconds(2f);                                    // 애니메이션 실행 시간 조절, 필요한 경우 값을 변경하세요

        preferencesObject.SetActive(false);

        if (isVolumeClicked)
        {
                                                                                // Volume_Click가 클릭된 상태라면 추가적인 동작 수행
                                                                                // 예: 다른 함수 호출, 상태 변경 등
                                                                                // 여기서는 true를 반환하도록 설정하겠습니다.
            isVolumeClicked = false;
                                                                                // 추가 동작 수행 후 반환
            yield return true;
        }
    }
}
