using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_anim : MonoBehaviour
{
    public Animator animator;

    private bool isWaiting = true;

    private void Start()
    {
                                      // �ִϸ����͸� ��� ���·� ����
        animator.enabled = false;
    }

    private void Update()
    {
        if (isWaiting)
        {
                                                 // ��� ���¿��� ��ư�� Ŭ���ϸ� �ִϸ����͸� Ȱ��ȭ�ϰ� ����
            if (Input.GetMouseButtonDown(0))
            {
                isWaiting = false;
                animator.enabled = true;
                animator.SetTrigger("RunAnimation"); // �ִϸ��̼��� �����ϴ� Ʈ���� �̸�
            }
        }
    }
}
