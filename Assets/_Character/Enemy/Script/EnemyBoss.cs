using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Damage;

namespace Character
{
    public partial class EnemyBoss : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;
        [SerializeField] BoxCollider leftAxe;
        [SerializeField] BoxCollider rightAxe;

        [SerializeField] TMP_Text eStateText;
        [SerializeField] ParticleSystem tornado;
        [SerializeField] GameObject flame;

        Vector3 originPos;
        Quaternion originRot;

        public Slider hpSlider;

        public bool IsDamaged { get; set; }

        #region Enemy ����
        [SerializeField] int maxHp = 100;
        public int hp = 100;

        #endregion


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

        // state���� �����ϴ� ��ųʸ� ����
        private Dictionary<EnemyBossState, State<EnemyBoss>> dicState =
            new Dictionary<EnemyBossState, State<EnemyBoss>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            hpSlider = GetComponentInChildren<Slider>();

            // ���� ����
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
            hpSlider.value = (float)hp / (float)maxHp;

            // �ʱ� ��ġ�� ���� ����
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

            hpSlider.value = (float)hp / (float)maxHp;
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