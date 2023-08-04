using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace State
{
    public partial class Enemy0 : MonoBehaviour
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

        #region Enemy ����
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

        IState<Enemy0> eState;


        // state���� �����ϴ� ��ųʸ� ����
        private Dictionary<EnemyState, IState<Enemy0>> dicState =
            new Dictionary<EnemyState, IState<Enemy0>>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            capsuleColider = GetComponent<CapsuleCollider>();

            hpSlider = GetComponentInChildren<Slider>();

            // ���� ����
            IState<Enemy0> idle = new IdleState();
            IState<Enemy0> move = new ChaseState();
            IState<Enemy0> attack = new AttackState();
            IState<Enemy0> damaged = new DamagedState();
            IState<Enemy0> getReturn = new ReturnState();
            IState<Enemy0> dead = new DeadState();

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
            IState<Enemy0> newState = eState.InputHandle(this);
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
            // ���� ���¸� ���� ���� ����
            if (eState == dicState[EnemyState.Dead])
            {
                return;
            }
            else if (other.CompareTag("Weapon"))
            {
                bDamaged = true;

                // SwordAttack ��ũ��Ʈ�� ���� trigger�� �Ͼ ����(�� �ڽ� ������Ʈ�� ��ġ�Ǿ� ����)����
                // ������ ������Ʈ�� ��ġ�ϹǷ� GetComponentInParent ���
                // �ִϸ��̼� �̺�Ʈ ������ unitychan ������Ʈ�� �Ҵ��ؾ���
                int damage = other.GetComponentInParent<Item.Data.SwordAttack>().weaponDamage;
                hp -= damage;

                // ���� enemy pos���� �ݶ��̴��� ���̸�ŭ ���� ��ġ�� ������ text ����
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (eState == dicState[EnemyState.Dead])
            {
                return;
            }
            else if (other.CompareTag("Skill1"))
            {
                bDamaged = true;
                int damage = other.GetComponent<Skill1>().weaponDamage;
                hp -= damage;

                // ���� enemy pos���� �ݶ��̴��� ���̸�ŭ ���� ��ġ�� ������ text ����
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Skill.DamageFactory.Instance.CreateTMP(pos, damage);
            }
            
        }

    }
}

