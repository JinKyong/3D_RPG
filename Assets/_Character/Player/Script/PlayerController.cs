using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using System.Linq;
using TMPro;
using Public;

namespace Character.State
{
    public partial class PlayerController : MonoBehaviour
    {
        Vector3 dir;
        Rigidbody rb;
        Animator anim;

        [SerializeField] TMP_Text pStateText;
        [SerializeField] ParticleSystem skill2;
        [SerializeField] ParticleSystem skill3;

        bool bDamaged;
        public bool IsDamaged { get; set; }


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

        State<PlayerController> state;

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<PlayerState, State<PlayerController>> dicState =
            new Dictionary<PlayerState, State<PlayerController>>();

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

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            // 상태 생성
            State<PlayerController> idle = new IdleState();
            State<PlayerController> run = new RunState();
            State<PlayerController> jump = new JumpState();
            State<PlayerController> fall = new FallState();
            State<PlayerController> attack = new AttackState();
            State<PlayerController> skill1 = new Skill1State();
            State<PlayerController> skill2 = new Skill2State();
            State<PlayerController> skill3 = new Skill3State();
            State<PlayerController> damaged = new DamagedState();
            State<PlayerController> dead = new DeadState();

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

            state = idle;

            //test
            controller = anim.runtimeAnimatorController as AnimatorController;
            testState = controller.layers[0].stateMachine.states.FirstOrDefault(s => s.state.name.Equals("testSkill")).state;
            State<PlayerController> skill = new TestSkillState();
            dicState.Add(PlayerState.test, skill);
        }

        private void Update()
        {
            pStateText.text = state.ToString();
            State<PlayerController> newState = state.InputHandle(this);
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

            return dir != Vector3.zero;
        }
    }
}
