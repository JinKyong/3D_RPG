using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.State;


namespace Player.CamRotate
{
    public class CameraRotate : MonoBehaviour
    {
        public PlayerController player;
        [SerializeField] float SensitivityX;
        [SerializeField] float SensitivityY;


        private void Start()
        {
            SensitivityX = 1.5f;
            SensitivityY = 1f;
        }

        private void Update()
        {
            LookAround();
        }

        private void LateUpdate()
        {
            transform.position = player.transform.position;        
        }

        private void LookAround()
        {
            float mouseX = Input.GetAxis("Mouse X") * SensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * SensitivityY; 
            Vector3 camAngle = transform.rotation.eulerAngles;

            // 카메라 이동 범위 제한 (상하: 350도 ~ 20도 )
            float limitAngleX = (camAngle.x - mouseY);


            if (limitAngleX > 180)
            {
                limitAngleX = Mathf.Clamp(limitAngleX, 350f, 360f);
            }
            else
            {
                limitAngleX = Mathf.Clamp(limitAngleX, -1f, 20f);
            }

            transform.rotation = Quaternion.Euler(limitAngleX, camAngle.y + mouseX, camAngle.z);
        }
    }

}

