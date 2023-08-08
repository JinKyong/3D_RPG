using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Character
{
    public partial class Enemy0 : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;
        CapsuleCollider capsuleColider;

        [SerializeField] TMP_Text eStateText;

        Vector3 originPos;
        Quaternion originRot;

        public Slider hpSlider;

        bool bDamaged;

        #region Enemy 스탯
        [SerializeField] int maxHp = 100;
        [SerializeField] int hp = 100;
        public int damage = 3;
        #endregion


        private enum EnemyState
        {
            Idle,
            Move,
            Attack,
            Damaged,
            Return,
            Dead,
        }

        State<Enemy0> eState;


        // state들을 보관하는 딕셔너리 생성
        private Dictionary<EnemyState, State<Enemy0>> dicState =
            new Dictionary<EnemyState, State<Enemy0>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            capsuleColider = GetComponent<CapsuleCollider>();

            hpSlider = GetComponentInChildren<Slider>();

            // 상태 생성
            State<Enemy0> idle = new IdleState();
            State<Enemy0> move = new ChaseState();
            State<Enemy0> attack = new AttackState();
            State<Enemy0> damaged = new DamagedState();
            State<Enemy0> getReturn = new ReturnState();
            State<Enemy0> dead = new DeadState();

            dicState.Add(EnemyState.Idle, idle);
            dicState.Add(EnemyState.Move, move);
            dicState.Add(EnemyState.Attack, attack);
            dicState.Add(EnemyState.Damaged, damaged);
            dicState.Add(EnemyState.Return, getReturn);
            dicState.Add(EnemyState.Dead, dead);

            // 기본 상태 설정
            eState = idle;
            hpSlider.value = (float)hp / (float)maxHp;

            // 초기 위치와 방향 저장
            originPos = transform.position;
            originRot = transform.rotation;

        }

        private void Update()
        {
            eStateText.text = eState.ToString();
            State<Enemy0> newState = eState.InputHandle(this);
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
            if (eState == dicState[EnemyState.Dead])
            {
                return;
            }
            
            bDamaged = true;

                // SwordAttack 스크립트는 실제 trigger가 일어난 무기(손 자식 오브젝트에 위치되어 있음)보다
                // 상위에 오브젝트에 위치하므로 GetComponentInParent 사용
                // 애니메이션 이벤트 때문에 unitychan 오브젝트에 할당해야함
            hp -= damage;

                // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
            Vector3 pos = transform.position;
            pos.y += capsuleColider.height;
                //Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);

        }

        private void OnParticleCollision(GameObject other)
        {
            Debug.Log(other.name);
            if (eState == dicState[EnemyState.Dead])
            {
                return;
            }

            bDamaged = true;
            // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
            Vector3 pos = transform.position;
            pos.y += capsuleColider.height;
            //Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);            
        }
    }
}

