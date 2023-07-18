using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace Player.State
{
    public partial class PlayerController : MonoBehaviour
    {
        Vector3 dir;
        public Rigidbody rb;
        public Animator anim;
        public AnimationClip atkClip;
        public AnimationClip dmgClip;

        [SerializeField] TMP_Text pStateText;
        public Slider hpSlider;
        bool bDamaged;

        #region 캐릭터 스탯
        [SerializeField] int maxHp = 100;
        [SerializeField] int hp = 100;
        #endregion



        private enum PlayerState
        {
            Idle,
            Run,
            Jump,
            Fall,
            Attack,
            Damaged,
            Dead,
        }

        IState state;

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<PlayerState, IState> dicState =
            new Dictionary<PlayerState, IState>();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            // 상태 생성
            IState idle = new StateIdle();
            IState run = new StateRun();
            IState jump = new StateJump();
            IState fall = new StateFall();
            IState attack = new StateAttack();
            IState damaged = new StateDamaged();
            IState dead = new StateDead();

            dicState.Add(PlayerState.Idle, idle);
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Attack, attack);
            dicState.Add(PlayerState.Damaged, damaged);
            dicState.Add(PlayerState.Dead, dead);

            // 기본 상태 설정
            state = idle;
            hpSlider.value = (float)hp / (float)maxHp;
        }

        private void Update()
        {
            pStateText.text = state.ToString();
            IState newState = state.InputHandle(this);
            if (newState == state )
            {
                return;
            }

            state.OperateExit(this);
            state = newState;
            state.OperateEnter(this);

            hpSlider.value = (float)hp / (float)maxHp;
        }

        private void FixedUpdate()
        {
            state.OperateUpdate(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("데미지 입음");
                bDamaged = true;
            }
        }

        private bool moveInput()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            dir = new Vector3(h, 0, v);

            anim.SetFloat("VelocityX", h);
            anim.SetFloat("VelocityZ", v);

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
                    // Space 버튼이 눌리고 점프상태가 아니면 점프할 수 있도록 함
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
