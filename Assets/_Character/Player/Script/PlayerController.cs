using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Public;

namespace Character.State
{
    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }

    public partial class PlayerController : Singleton<PlayerController>
    {
        Vector3 dir;
        Rigidbody rb;
        Animator anim;

        [SerializeField] TMP_Text pStateText;

        public bool IsDamaged { get; set; }
        public bool OnSkill { get; set; }

        //test
        AnimatorOverrideController overrideController;
        AnimationClipOverrides clipOverrides;
        public AnimationClip skillClip;

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
            Skill,
            Damaged,
            Dead,
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
            State<PlayerController> skill = new SkillState();
            State<PlayerController> damaged = new DamagedState();
            State<PlayerController> dead = new DeadState();

            dicState.Add(PlayerState.Idle, idle);
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Attack, attack);
            dicState.Add(PlayerState.Skill, skill);
            dicState.Add(PlayerState.Damaged, damaged);
            dicState.Add(PlayerState.Dead, dead);

            state = idle;

            //skill state
            overrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
            anim.runtimeAnimatorController = overrideController;

            clipOverrides = new AnimationClipOverrides(overrideController.overridesCount);
            overrideController.GetOverrides(clipOverrides);
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

        public void TakeDamage()
        {
            if (state == dicState[PlayerState.Dead])
            {
                return;
            }

            IsDamaged = true;
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
