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

                if (e.bDamaged)
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

                if (e.bDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }
                

                return this;
            }
        }

        public class AttackState : State<Enemy0>
        {
            float atkAnimDuration;
            float elapsedTime;

            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Attack");
                elapsedTime = 0f;
                atkAnimDuration = e.atkClip.length;
            }

            public override void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
            }

            public override void OperateExit(Enemy0 e)
            {
            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (e.bDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }
                else if (elapsedTime >= atkAnimDuration)
                {
                    return e.dicState[EnemyState.Move];
                }

                return this;
            }
        }

        public class DamagedState : State<Enemy0>
        {
            float dmgAnimDuration;
            float elapsedTime;

            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = e.dmgClip.length;
            }

            public override void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
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
                else if (elapsedTime >= dmgAnimDuration)
                {
                    e.bDamaged = false;
                    return e.dicState[EnemyState.Move];
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
            float deadAnimDuration;
            float elapsedTime;

            public override void OperateEnter(Enemy0 e)
            {
                e.anim.SetBool("Dead", true);
                elapsedTime = 0f;                
                deadAnimDuration = e.deadClip.length;
            }

            public override void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
            }

            public override void OperateExit(Enemy0 e)
            {

            }

            public override State<Enemy0> InputHandle(Enemy0 e)
            {
                if (elapsedTime >= deadAnimDuration)
                {
                    PoolManager.Instance.Push(e.gameObject);
                }
                return this;
            }
        }
    }
}
