using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        Vector3 dir;
        Rigidbody rb;
        Animator ani;

        public Transform followCam;

        private bool bJumping;

        private float jumpPower = 300f;

        [SerializeField] float moveSpeed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            ani = GetComponentInChildren<Animator>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector3 dInput = context.ReadValue<Vector3>();
            if (dInput != null)
            {
                // Inputsystem으로 Vector3값을 받아서 blendTree에 parameter값에 대입
                dir = followCam.forward * dInput.z + followCam.right * dInput.x;
                transform.forward = new Vector3(followCam.forward.x, 0, followCam.forward.z);

                ani.SetFloat("VelocityX", dInput.x);
                ani.SetFloat("VelocityZ", dInput.z);
                Debug.Log("x : " + dInput.x);
                Debug.Log("z : " + dInput.z);
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {   
            // Space 버튼이 눌리고 점프상태가 아니면 점프할 수 있도록 함
            if (context.performed && !bJumping)
            {
                ani.SetTrigger("isJumping");
                bJumping = true;
                rb.AddForce(Vector3.up * jumpPower);
                Debug.Log("Jump");
            }            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                bJumping = false;
            }
        }

        private void Update()
        {
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }
}
