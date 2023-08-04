using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Enemy.State
{
    public partial class BossController : MonoBehaviour
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

        public Slider hpSlider;

        bool bDamaged;

        #region Enemy 스탯
        [SerializeField] int maxHp = 100;
        [SerializeField] int hp = 100;
        public int damage = 5;
        #endregion


        private enum BossState
        {
            Idle,
            Move,
            Attack,
            Damaged,
            Return,
            Dead,
        }

        IBossState eState;

        // state들을 보관하는 딕셔너리 생성
        private Dictionary<BossState, IBossState> dicState =
            new Dictionary<BossState, IBossState>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            capsuleColider = GetComponent<CapsuleCollider>();

            hpSlider = GetComponentInChildren<Slider>();

            // 상태 생성
            IBossState idle = new StateIdle();
            IBossState move = new StateMove();
            IBossState attack = new StateAttack();
            IBossState damaged = new StateDamaged();
            IBossState getReturn = new StateReturn();
            IBossState dead = new StateDead();

            dicState.Add(BossState.Idle, idle);
            dicState.Add(BossState.Move, move);
            dicState.Add(BossState.Attack, attack);
            dicState.Add(BossState.Damaged, damaged);
            dicState.Add(BossState.Return, getReturn);
            dicState.Add(BossState.Dead, dead);

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
            IBossState newState = eState.InputHandle(this);
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
            if (other.CompareTag("Weapon"))
            {
                Debug.Log("무기 충돌");
                bDamaged = true;

                // SwordAttack 스크립트는 애니메이터 때문에 unitychan 오브젝트에 있어야하는데
                // 실제 trigger가 일어난 무기(손 자식 오브젝트에 위치되어 있음)보다 상위에 위치하므로
                // GetComponentInParent 사용
                int damage = other.GetComponentInParent<Item.Data.SwordAttack>().weaponDamage;
                hp -= damage;

                // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Skill1"))
            {
                bDamaged = true;
                int damage = other.GetComponent<Skill1>().weaponDamage;
                hp -= damage;

                // 현재 enemy pos에서 콜라이더의 높이만큼 더한 위치에 데미지 text 생성
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);
            }

        }

    }
}