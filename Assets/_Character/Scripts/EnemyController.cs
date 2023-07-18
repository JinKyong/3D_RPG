using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Enemy.State
{
    public partial class EnemyController : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;
        CapsuleCollider capsuleColider;

        [SerializeField] TMP_Text eStateText;
        [SerializeField] AnimationClip atkClip;
        [SerializeField] AnimationClip dmgClip;
        [SerializeField] AnimationClip deadClip;
        Vector3 originPos;
        Quaternion originRot;

        [SerializeField] int maxHp = 100;
        [SerializeField] int hp = 100;
        public Slider hpSlider;

        bool bDamaged;

        private enum EnemyState
        {
            Idle,
            Move,
            Attack,
            Damaged,
            Return,
            Dead,
        }

        IEnemyState eState;


        // state들을 보관하는 딕셔너리 생성
        private Dictionary<EnemyState, IEnemyState> dicState =
            new Dictionary<EnemyState, IEnemyState>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            capsuleColider = GetComponent<CapsuleCollider>();

            hpSlider = GetComponentInChildren<Slider>();

            // 상태 생성
            IEnemyState idle = new StateIdle();
            IEnemyState move = new StateMove();
            IEnemyState attack = new StateAttack();
            IEnemyState damaged = new StateDamaged();
            IEnemyState getReturn = new StateReturn();
            IEnemyState dead = new StateDead();

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
            IEnemyState newState = eState.InputHandle(this);
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
            if (other.gameObject.CompareTag("Weapon"))
            {
                Debug.Log("무기 충돌");
                bDamaged = true;
                
                // SwordAttack 스크립트는 애니메이터 때문에 unitychan 오브젝트에 있어야하므로
                // 실제 trigger가 일어난 무기(손 자식 오브젝트에 위치되어 있음)보다 상위에 있으므로
                // GetComponentInParent 사용
                int damage = other.GetComponentInParent<SwordAttack>().weaponDamage;
                hp -= damage;

                //Vector3 pos = transform.position;
                //pos.y += capsuleColider.height;
                //DamageFactory.Instance.CreateTMP(pos, 50);
            }
        }
    }
}

