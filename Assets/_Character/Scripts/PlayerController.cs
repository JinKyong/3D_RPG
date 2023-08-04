using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Animations;
using System.Linq;
using Public;

namespace State
{
    public partial class PlayerController : MonoBehaviour
    {
        Vector3 dir;
        Rigidbody rb;
        Animator anim;
        public AnimationClip atkClip;
        public AnimationClip dmgClip;

        public AnimationClip sk1Clip;

        public AnimationClip sk2Clip;
        [SerializeField] ParticleSystem skill2;

        public AnimationClip sk3Clip;
        [SerializeField] ParticleSystem skill3;

        [SerializeField] TMP_Text pStateText;
        [SerializeField] TMP_Text HpText;
        [SerializeField] TMP_Text MpText;

        [SerializeField] Slider hpSlider;
        [SerializeField] Slider mpSlider;
        bool bDamaged;


        #region 캐릭터 스탯
        int maxHp = 100;
        int hp = 100;
        int maxMp = 100;
        int mp = 100;

        // 공격받은 데미지
        int damaged;
        #endregion


        //test
        AnimatorController controller;
        AnimatorState testState;
        public AnimationClip testClip;

        private enum PlayerState
        {
            Idle,
            Run,
            Jump,
            Fall,
            Attack,
            Skill1,
            Skill2,
            Skill3,
            Damaged,
            Dead,
            test
        }

       IState<PlayerController> state;

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<PlayerState, IState<PlayerController>> dicState =
            new Dictionary<PlayerState, IState<PlayerController>>();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            // 상태 생성
            IState<PlayerController> idle = new IdleState();
            IState<PlayerController> run = new RunState();
            IState<PlayerController> jump = new JumpState();
            IState<PlayerController> fall = new FallState();
            IState<PlayerController> attack = new AttackState();
            IState<PlayerController> skill1 = new Skill1State();
            IState<PlayerController> skill2 = new Skill2State();
            IState<PlayerController> skill3 = new Skill3State();
            IState<PlayerController> damaged = new DamagedState();
            IState<PlayerController> dead = new DeadState();

            dicState.Add(PlayerState.Idle, idle);
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Attack, attack);
            dicState.Add(PlayerState.Skill1, skill1);
            dicState.Add(PlayerState.Skill2, skill2);
            dicState.Add(PlayerState.Skill3, skill3);
            dicState.Add(PlayerState.Damaged, damaged);
            dicState.Add(PlayerState.Dead, dead);

            // 기본 상태 설정
            state = idle;
            hpSlider.value = (float)hp / (float)maxHp;
            mpSlider.value = (float)mp / (float)maxMp;

            //test
            controller = anim.runtimeAnimatorController as AnimatorController;
            testState = controller.layers[0].stateMachine.states.FirstOrDefault(s => s.state.name.Equals("testSkill")).state;
            IState<PlayerController> skill = new TestSkillState();
            dicState.Add(PlayerState.test, skill);
        }

        private void Update()
        {
            pStateText.text = state.ToString();
            IState<PlayerController> newState = state.InputHandle(this);
            if (newState == state )
            {
                return;
            }
            state.OperateExit(this);
            state = newState;
            state.OperateEnter(this);

            hpSlider.value = (float)hp / (float)maxHp;
            mpSlider.value = (float)mp / (float)maxMp;
            HpText.text = $"Hp : {hp} / {maxHp}";
            MpText.text = $"Mp : {mp} / {maxMp}";
        }

        private void FixedUpdate()
        {
            state.OperateUpdate(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy0"))
            {
                bDamaged = true;
                damaged = other.GetComponentInParent<Enemy0>().damage;
            }
            else if (other.CompareTag("EnemyBoss"))
            {
                bDamaged = true;
                damaged = other.GetComponentInParent<EnemyBoss>().axeDamage;
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Flame"))
            {
                bDamaged = true;
                damaged = other.GetComponentInParent<EnemyBoss>().flameDamage;
            }
            else if (other.CompareTag("Tornado"))
            {
                bDamaged = true;
                damaged = other.GetComponentInParent<EnemyBoss>().tornadoDamage;
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
