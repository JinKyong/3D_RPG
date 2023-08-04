using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;


namespace CharMove
{ 
    public class CharMove : MonoBehaviour
    {
        private Rigidbody rigidbody;
        [SerializeField] float speed = 10f;
        [SerializeField] float jumpHeight = 3f;
     /*   [SerializeField] float dash = 5f;*/
        [SerializeField] float rotSpeed = 3f;
        [SerializeField] LayerMask layer;

        private Vector3 dir = Vector3.zero;

        private bool ground = false;

        private void Start()
        {
            rigidbody = this.GetComponent<Rigidbody>();

        }
        private void Update()
        {
        /*    Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
            if (Physics.Raycast(transform.position, transform.forward))
            {
                Debug.Log("�浹");
            }    */

            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");
            dir.Normalize();
             CheckGround();

            if (Input.GetButtonDown("Jump") && ground) 
            {
                Debug.Log("����!");
                Vector3 jumpPower = Vector3.up * jumpHeight;
                rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
            }
        /*    if (Input.GetButtonDown("Dash"))
            { 
            
            
            
            }*/
     
        }
                
        private void FixedUpdate()
        {

            if (dir != Vector3.zero)
            {
                if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))

                {
                    transform.Rotate(0, 1, 0);
                }
                transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
            }

            rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime); ;
        }

        void CheckGround()
        {
            Debug.Log("��!");
            RaycastHit hit;

            if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
            {
                ground = true;
            }
            else
            {
                ground = false;
            }
        }
        
    }
}
