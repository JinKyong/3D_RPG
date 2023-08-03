using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float dash = 5f;
    [SerializeField] float rotSpeed = 3f;

    private Vector3 dir = Vector3.zero;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

    }
    private void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
     
    }
    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {

            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime); ;
    }
}
