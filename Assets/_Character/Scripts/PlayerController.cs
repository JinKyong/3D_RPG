using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace Player.State
{
    public partial class PlayerController : MonoBehaviour
    {
        Vector3 dir;
        public Rigidbody rb;
        public Animator ani;
        public AnimationClip atkClip;

        [SerializeField] bool bGround;
        [SerializeField] TMP_Text stateText;

        private enum PlayerState
        {
            Idle,
            Run,
            Jump,
            Fall,
            Attack,
            Dead,
        }

        IState state;

        // state���� �����ϴ� ��ųʸ� ����
        private Dictionary<PlayerState, IState> dicState =
            new Dictionary<PlayerState, IState>();

        private void Start()
        {
            // ���� ����
            IState idle = new StateIdle();
            IState run = new StateRun();
            IState jump = new StateJump();
            IState fall = new StateFall();
            IState attack = new StateAttack();
            IState dead = new StateDead();

            dicState.Add(PlayerState.Idle, idle);
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Attack, attack);
            dicState.Add(PlayerState.Dead, dead);

            // �⺻ ���� ����
            state = idle;

            rb = GetComponent<Rigidbody>();
            ani = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            stateText.text = state.ToString(); 
            IState newState = state.InputHandle(this);
            if (newState == state )
            {
                return;
            }

            state.OperateExit(this);
            state = newState;
            state.OperateEnter(this);
        }

        private void FixedUpdate()
        {
            state.OperateUpdate(this);
        }


        private bool moveInput()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            dir = new Vector3(h, 0, v);

            ani.SetFloat("VelocityX", h);
            ani.SetFloat("VelocityZ", v);

            return dir != Vector3.zero;
        }

        private bool jumpInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        /*        public void OnMove(InputAction.CallbackContext context)
                {
                    Vector3 dInput = context.ReadValue<Vector3>();
                    if (dInput != null)
                    {                
                        dir = Camera.main.transform.forward * dInput.z + Camera.main.transform.right * dInput.x;
                        transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

                        ani.SetFloat("VelocityX", dInput.x);
                        ani.SetFloat("VelocityZ", dInput.z);
                    }
                }

                public void OnJump(InputAction.CallbackContext context)
                {
                    // Space ��ư�� ������ �������°� �ƴϸ� ������ �� �ֵ��� ��
                    if (context.performed)
                    {
                        ani.SetTrigger("isJumping");
                        rb.AddForce(Vector3.up);
                        Debug.Log("Jump");
                    }
                }

                private void LateUpdate()
                {
                    rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }*/

    }
}
