using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public partial class Enemy0 : MonoBehaviour
    {
        public class IdleState : State<Enemy0>
        {
            float findDistance = 16f;
            public override void OperateEnter(Enemy0 e)
            {
            }

            public override void OperateUpdate(Enemy0 e)
            {
            }

            public override void OperateExit(Enemy0 e)
            {
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (Vector3.Distance(e.transform.position , e.player.transform.position) < findDistance)
                {
                    return e.dicState[EnemyState.Move];
                }

                if (e.IsDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }

                return this;
            }
        }

        public class ChaseState : State<Enemy0>
        {
            float atkDistance = 2f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetBool("RunForward", true);
            }

            public override void OperateUpdate(Enemy0 e)
            {           
                // 플레이어 쪽으로 방향 틀고 이동
                // dir은 월드 좌표고 translate은 로컬 좌표 기준으로 앞으로 움직이므로 같이 사용 불가
                dir = (e.player.transform.position - e.transform.position).normalized;
                e.transform.forward = dir;
                e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public override void OperateExit(Enemy0 e)
            {
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (Vector3.Distance(e.player.transform.position, e.transform.position) < atkDistance)
                {
                    return e.dicState[EnemyState.Attack];
                }
                else if (Vector3.Distance(e.player.transform.position, e.transform.position) > returnDistance)
                {
                    return e.dicState[EnemyState.Return];
                }

                if (e.IsDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }
                

                return this;
            }
        }

        public class AttackState : State<Enemy0>
        {
            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Attack");
            }

            public override void OperateUpdate(Enemy0 e)
            {
            }

            public override void OperateExit(Enemy0 e)
            {
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (e.IsDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }
                else if (e.anim.GetCurrentAnimatorStateInfo(0).IsName("Bear_Attack5")
                    && e.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
                {
                    return e.dicState[EnemyState.Idle];
                }

                return this;
            }
        }

        public class DamagedState : State<Enemy0>
        {
            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Damaged");
            }

            public override void OperateUpdate(Enemy0 e)
            {
            }

            public override void OperateExit(Enemy0 e)
            {
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (e.hpSlider.value <= 0)
                {
                    return e.dicState[EnemyState.Dead];
                }
                else if (e.anim.GetCurrentAnimatorStateInfo(0).IsName("Bear_GetHit")
                    && e.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
                {
                    e.IsDamaged = false;
                    return e.dicState[EnemyState.Idle];
                }

                return this;
            }
        }

        public class ReturnState : State<Enemy0>
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public override void OperateEnter(Enemy0 e)
            {
            }

            public override void OperateUpdate(Enemy0 e)
            {
                // 원래 위치로 방향 틀고 이동
                if (Vector3.Distance(e.transform.position, e.originPos) > 1f)
                {
                    dir = (e.originPos - e.transform.position).normalized;
                    e.transform.forward = dir;
                    e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public override void OperateExit(Enemy0 e)
            {
                e.anim.SetBool("RunForward", false);
                e.transform.position = e.originPos;
                e.transform.rotation = e.originRot;
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (Vector3.Distance(e.transform.position, e.originPos) < 1f)                
                {
                    return e.dicState[EnemyState.Idle];
                }
                return this;
            }
        }

        public class DeadState : State<Enemy0>
        {
            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetBool("Dead", true);
            }

            public override void OperateUpdate(Enemy0 e)
            {
            }

            public override void OperateExit(Enemy0 e)
            {

            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (e.anim.GetCurrentAnimatorStateInfo(0).IsName("Bear_Death")
                    && e.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
                {
                    PoolManager.Instance.Push(e.gameObject);
                }
                return this;
            }
        }
    }
}
