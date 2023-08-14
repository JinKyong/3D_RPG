using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Damage;
using Public;

namespace Character
{
    public partial class EnemyBoss : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;

        [SerializeField] TMP_Text eStateText;

        Vector3 originPos;
        Quaternion originRot;

        public Slider hpSlider;

        public bool IsDamaged { get; set; }

        #region Enemy 스탯
        [SerializeField] float maxHp = 100;
        [SerializeField] float hp = 100;

        #endregion

        [SerializeField] GameEvent bossDead;


        private enum EnemyBossState
        {
            Idle,
            Chase,
            Attack1,
            Attack2,
            Attack3,
            Damaged,
            Return,
            Dead,
        }

        State<EnemyBoss> eState;

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<EnemyBossState, State<EnemyBoss>> dicState =
            new Dictionary<EnemyBossState, State<EnemyBoss>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            hpSlider = GetComponentInChildren<Slider>();

            // 상태 생성
            State<EnemyBoss> idle = new IdleState();
            State<EnemyBoss> chase = new ChaseState();
            State<EnemyBoss> axeAtk = new AxeAtkState();
            State<EnemyBoss> roarAtk = new RoarAtkState();
            State<EnemyBoss> tornadoAtk = new TornadoAtkState();
            State<EnemyBoss> damaged = new DamagedState();
            State<EnemyBoss> getReturn = new ReturnState();
            State<EnemyBoss> dead = new DeadState();



            dicState.Add(EnemyBossState.Idle, idle);
            dicState.Add(EnemyBossState.Chase, chase);
            dicState.Add(EnemyBossState.Attack1, axeAtk);
            dicState.Add(EnemyBossState.Attack2, roarAtk);
            dicState.Add(EnemyBossState.Attack3, tornadoAtk);
            dicState.Add(EnemyBossState.Damaged, damaged);
            dicState.Add(EnemyBossState.Return, getReturn);
            dicState.Add(EnemyBossState.Dead, dead);

            eState = idle;

            // 초기 위치와 방향 저장
            originPos = transform.position;
            originRot = transform.rotation;

        }

        private void Update()
        {
            eStateText.text = eState.ToString();
            State<EnemyBoss> newState = eState.InputHandle(this);
            if (newState == eState)
            {
                return;
            }

            eState.OperateExit(this);
            eState = newState;
            eState.OperateEnter(this);
        }

        public void ControlStat(float health)
        {
            hp += health;

            hpSlider.value = hp / maxHp;
        }

        private void FixedUpdate()
        {
            eState.OperateUpdate(this);
        }

        public void TakeDamage()
        {
            if (eState == dicState[EnemyBossState.Dead])
            {
                return;
            }

            IsDamaged = true;
        }
    }
}