using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_anim : MonoBehaviour
{
    public Animator animator;

    private bool isWaiting = true;

    private void Start()
    {
                                      // 애니메이터를 대기 상태로 설정
        animator.enabled = false;
    }

    private void Update()
    {
        if (isWaiting)
        {
                                                 // 대기 상태에서 버튼을 클릭하면 애니메이터를 활성화하고 실행
            if (Input.GetMouseButtonDown(0))
            {
                isWaiting = false;
                animator.enabled = true;
                animator.SetTrigger("RunAnimation"); // 애니메이션을 실행하는 트리거 이름
            }
        }
    }
}
