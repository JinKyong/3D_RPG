using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class CameraRotate : MonoBehaviour
{
    //�������� ���� �ϳ� �߰�
    //Ÿ�� ��ŸŸ�� �����ٰ�
    public PlayerController player;

    private void Update()
    {
        LookAround();
        transform.position = player.transform.position;
    }

    private void LookAround()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
        Vector3 camAngle = transform.rotation.eulerAngles;

        // ���� �¿������� ���ʿ� - ī�޶� �̵� ���� ���� (����: 350�� ~ 20�� , �¿�: 300�� ~ 60��)
        float limitAngleX = camAngle.x - mouse_Y;


        if (limitAngleX > 180)
        {
            limitAngleX = Mathf.Clamp(limitAngleX, 350, 360);
        }
        else
        {
            limitAngleX = Mathf.Clamp(limitAngleX, -1, 20);
        }


        transform.rotation = Quaternion.Euler(limitAngleX, camAngle.y + mouse_X, camAngle.z);
    }
}
