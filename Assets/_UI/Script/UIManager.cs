using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject preferencesObject;
    public Animator[] backAnimators; // 변수 이름을 소문자로 시작하도록 수정
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
            StartCoroutine(DisableAfterAnimation(animator)); // Coroutine 내부에서도 animator를 사용할 수 있도록 수정
        }
    }

    private IEnumerator DisableAfterAnimation(Animator animator) // IEnumerator에 Animator 파라미터 추가
    {
        yield return new WaitForSeconds(2f); // 애니메이션 실행 시간 조절, 필요한 경우 값을 변경하세요

        preferencesObject.SetActive(false);
    }
}
