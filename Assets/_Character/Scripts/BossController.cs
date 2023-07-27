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

        #region Enemy ����
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

        // state���� �����ϴ� ��ųʸ� ����
        private Dictionary<BossState, IBossState> dicState =
            new Dictionary<BossState, IBossState>();


        private void Start()
        {
            player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
            capsuleColider = GetComponent<CapsuleCollider>();

            hpSlider = GetComponentInChildren<Slider>();

            // ���� ����
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
                Debug.Log("���� �浹");
                bDamaged = true;

                // SwordAttack ��ũ��Ʈ�� �ִϸ����� ������ unitychan ������Ʈ�� �־���ϴµ�
                // ���� trigger�� �Ͼ ����(�� �ڽ� ������Ʈ�� ��ġ�Ǿ� ����)���� ������ ��ġ�ϹǷ�
                // GetComponentInParent ���
                int damage = other.GetComponentInParent<Item.Data.SwordAttack>().weaponDamage;
                hp -= damage;

                // ���� enemy pos���� �ݶ��̴��� ���̸�ŭ ���� ��ġ�� ������ text ����
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Damage.DamageFactory.Instance.CreateTMP(pos, damage);
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Skill1"))
            {
                bDamaged = true;
                int damage = other.GetComponent<Skill1>().weaponDamage;
                hp -= damage;

                // ���� enemy pos���� �ݶ��̴��� ���̸�ŭ ���� ��ġ�� ������ text ����
                Vector3 pos = transform.position;
                pos.y += capsuleColider.height;
                Player.Damage.DamageFactory.Instance.CreateTMP(pos, damage);
            }

        }

    }
}