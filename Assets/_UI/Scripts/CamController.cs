using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamController
{ 
    public class CamController : MonoBehaviour
    {
        private float xRotate, yRotate, xRotateMove, yRotateMove;
        [SerializeField] float rotateSpeed = 500.0f;

        [SerializeField] GameObject TarGet;

        [SerializeField] float offsetX = 0.0f;
        [SerializeField] float offsetY = 10.0f;
        [SerializeField] float offsetZ = -10.0f;

        [SerializeField] float CameraSpeed = 10.0f;
        Vector3 TargetPos;

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
                yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

                yRotate = transform.eulerAngles.y + yRotateMove;
                xRotate = xRotate + xRotateMove;
                /*xRotate = transform.eulerAngles.x + xRotateMove;*/

                xRotate = Mathf.Clamp(xRotate, -90, 90);

                transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
            
            }
            TargetPos = new Vector3(
                TarGet.transform.position.x + offsetX,
                TarGet.transform.position.y + offsetY,
                TarGet.transform.position.z + offsetZ

                );
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        }



        /*public GameObject player;
        private Vector3 offset;
        // Start is called before the first frame update
        void Start()
        {
            offset = transform.position - player.transform.position;
        }
        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }*/


    }
}