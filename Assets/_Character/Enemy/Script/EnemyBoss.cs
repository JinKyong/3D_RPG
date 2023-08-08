using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Character
{
    public partial class EnemyBoss : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;
        CapsuleCollider bodyColider;
        [SerializeField] BoxCollider leftAxe;
        [SerializeField] BoxCollider rightAxe;

        [SerializeField] TMP_Text eStateText;
        [SerializeField] ParticleSystem tornado;
        [SerializeField] GameObject flame;

        Vector3 originPos;
        Quaternion originRot;

        public Slider hpSlider;

        bool bDamaged;

        #region Enemy 스탯
        [SerializeField] int maxHp = 100;
        [SerializeField] int hp = 100;
        public int axeDamage = 5;
        public int flameDamage = 10;
        public int tornadoDamage = 5;

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

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<EnemyBossState, State<EnemyBoss>> dicState =
            new Dictionary<EnemyBossState, State<EnemyBoss>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            bodyColider = GetComponent<CapsuleCollider>();

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
            hpSlider.value = (float)hp / (float)maxHp;

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

            hpSlider.value = (float)hp / (float)maxHp;
        }

        private void FixedUpdate()
        {
            eState.OperateUpdate(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (eState == dicState[EnemyBossState.Dead])
            {
                return;
            }

            if (other.CompareTag("Weapon"))
            {
                bDamaged = true;

                // SwordAttack 스크립트는 애니메이터 때문에 unitychan 오브젝트에 있어야하는데
                // 실제 trigger가 일어난 무기(손 자식 오브젝트에 위치되어 있음)보다 상위에 위치하므로
                // GetComponentInParent 사용
                int damage = other.GetComponentInParent<Item.Data.SwordAttack>().weaponDamage;
                hp -= damage;

                // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
                Vector3 pos = transform.position;
                pos.y += bodyColider.height;
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (eState == dicState[EnemyBossState.Dead])
            {
                return;
            }
            else if (other.CompareTag("Skill1"))
            {
                bDamaged = true;                

                // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
                Vector3 pos = transform.position;
                pos.y += bodyColider.height;
                //Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);
            }

        }

    }
}