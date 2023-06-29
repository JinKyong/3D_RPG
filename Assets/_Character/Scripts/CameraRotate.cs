using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        LookAround();
        transform.position = player.position;
    }

    private void LookAround()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
        Vector3 camAngle = transform.rotation.eulerAngles;

        // ���� �¿������� ���ʿ� - ī�޶� �̵� ���� ���� (����: 350�� ~ 20�� , �¿�: 300�� ~ 60��)
        float limitAngleX = camAngle.x - mouse_Y;
/*        float limitAngleY = camAngle.y + mouse_X;*/

        if (limitAngleX > 180)
        {
            limitAngleX = Mathf.Clamp(limitAngleX, 350, 360);
        }
        else
        {
            limitAngleX = Mathf.Clamp(limitAngleX, -1, 20);
        }

/*
        if (limitAngleY > 180)
        {
            limitAngleY = Mathf.Clamp(limitAngleY, 300, 360);
        }
        else
        {
            limitAngleY = Mathf.Clamp(limitAngleY, -1, 60);
        }
*/
        transform.rotation = Quaternion.Euler(limitAngleX, camAngle.y + mouse_X, camAngle.z);
    }
}
