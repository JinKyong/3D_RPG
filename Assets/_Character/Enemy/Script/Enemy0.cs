using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Damage;


namespace Character
{
    public partial class Enemy0 : MonoBehaviour
    {
        GameObject player;
        Rigidbody rb;
        Animator anim;

        [SerializeField] TMP_Text eStateText;

        Vector3 originPos;
        Quaternion originRot;

        public Slider hpSlider;

        public bool IsDamaged { get; set; }

        #region Enemy ����
        [SerializeField] float maxHp = 100;
        [SerializeField] float hp = 100;
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


        // state���� �����ϴ� ��ųʸ� ����
        private Dictionary<EnemyState, State<Enemy0>> dicState =
            new Dictionary<EnemyState, State<Enemy0>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();

            hpSlider = GetComponentInChildren<Slider>();

            // ���� ����
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

            // �⺻ ���� ����
            eState = idle;
            hpSlider.value = (float)hp / (float)maxHp;

            // �ʱ� ��ġ�� ���� ����
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

        public void ControlStat(float health)
        {
            hp += health;

            hpSlider.value = hp / maxHp;
        }


        public void TakeDamage()
        {
            if (eState == dicState[EnemyState.Dead])
            {
                return;
            }

            IsDamaged = true; 
        }
    }
}

