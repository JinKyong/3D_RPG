using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_anim : MonoBehaviour
{
    public Animator animator;                                   // 애니메이터 컴포넌트를 저장할 변수

    private bool isWaiting = true;                              // 애니메이션 실행을 대기하는 상태를 나타내는 변수

    private void Start()
    {
                                                                // 애니메이터를 비활성화하여 대기 상태로 설정
        animator.enabled = false;
    }

    private void Update()
    {
        if (isWaiting)
        {
                                                                // 대기 상태에서 버튼을 클릭하면 애니메이터를 활성화하고 실행
            if (Input.GetMouseButtonDown(0))
            {
                isWaiting = false;                              // 대기 상태 종료
                animator.enabled = true;                        // 애니메이터 활성화
                animator.SetTrigger("RunAnimation");            // "RunAnimation" 트리거를 호출하여 애니메이션 실행
            }
        }
    }
}
