using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_anim : MonoBehaviour
{
    public Animator animator;                                   // �ִϸ����� ������Ʈ�� ������ ����

    private bool isWaiting = true;                              // �ִϸ��̼� ������ ����ϴ� ���¸� ��Ÿ���� ����

    private void Start()
    {
                                                                // �ִϸ����͸� ��Ȱ��ȭ�Ͽ� ��� ���·� ����
        animator.enabled = false;
    }

    private void Update()
    {
        if (isWaiting)
        {
                                                                // ��� ���¿��� ��ư�� Ŭ���ϸ� �ִϸ����͸� Ȱ��ȭ�ϰ� ����
            if (Input.GetMouseButtonDown(0))
            {
                isWaiting = false;                              // ��� ���� ����
                animator.enabled = true;                        // �ִϸ����� Ȱ��ȭ
                animator.SetTrigger("RunAnimation");            // "RunAnimation" Ʈ���Ÿ� ȣ���Ͽ� �ִϸ��̼� ����
            }
        }
    }
}
