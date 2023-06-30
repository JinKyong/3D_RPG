using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class CameraRotate : MonoBehaviour
{
    //감도조절 변수 하나 추가
    //타임 델타타임 곱해줄것
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

        // 현재 좌우제한은 불필요 - 카메라 이동 범위 제한 (상하: 350도 ~ 20도 , 좌우: 300도 ~ 60도)
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
