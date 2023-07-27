using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace Enemy.State
{
    public partial class BossController : MonoBehaviour
    {
        public class StateIdle : IBossState
        {
            float findDistance = 16f;
            public void OperateEnter(BossController b)
            {
            }

            public void OperateUpdate(BossController b)
            {
            }

            public void OperateExit(BossController b)
            {
            }

            public IBossState InputHandle(BossController b)
            {
                if (Vector3.Distance(b.transform.position, b.player.transform.position) < findDistance)
                {
                    return b.dicState[BossState.Move];
                }

                if (b.bDamaged)
                {
                    return b.dicState[BossState.Damaged];
                }

                return this;
            }
        }

        public class StateMove : IBossState
        {
            float atkDistance = 2f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(BossController b)
            {
                b.anim.SetBool("Move", true);
            }

            public void OperateUpdate(BossController b)
            {
                // 플레이어 쪽으로 방향 틀고 이동
                // dir은 월드 좌표고 translate은 로컬 좌표 기준으로 앞으로 움직이므로 같이 사용 불가
                dir = (b.player.transform.position - b.transform.position).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public void OperateExit(BossController b)
            {
 
            }

            public IBossState InputHandle(BossController b)
            {
                if (Vector3.Distance(b.player.transform.position, b.transform.position) < atkDistance)
                {
                    return b.dicState[BossState.Attack];
                }
                else if (Vector3.Distance(b.player.transform.position, b.transform.position) > returnDistance)
                {
                    return b.dicState[BossState.Return];
                }

                if (b.bDamaged)
                {
                    return b.dicState[BossState.Damaged];
                }


                return this;
            }
        }

        public class StateAttack : IBossState
        {
            float atkAnimDuration;
            float elapsedTime;

            public void OperateEnter(BossController b)
            {
                b.anim.SetTrigger("Attack");
                elapsedTime = 0f;
                atkAnimDuration = b.atkClip.length;
            }

            public void OperateUpdate(BossController b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(BossController b)
            {
            }

            public IBossState InputHandle(BossController b)
            {
                if (elapsedTime >= atkAnimDuration)
                {
                    return b.dicState[BossState.Idle];
                }

                if (b.bDamaged)
                {
                    return b.dicState[BossState.Damaged];
                }

                return this;
            }
        }

        public class StateDamaged : IBossState
        {
            float dmgAnimDuration;
            float elapsedTime;

            public void OperateEnter(BossController b)
            {
                b.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = b.dmgClip.length;
            }

            public void OperateUpdate(BossController b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(BossController b)
            {
            }

            public IBossState InputHandle(BossController b)
            {
                if (b.hpSlider.value <= 0)
                {
                    return b.dicState[BossState.Dead];
                }
                else if (elapsedTime >= dmgAnimDuration)
                {
                    b.bDamaged = false;
                    return b.dicState[BossState.Move];
                }

                return this;
            }
        }

        public class StateReturn : IBossState
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(BossController b)
            {
            }

            public void OperateUpdate(BossController b)
            {
                // 원래 위치로 방향 틀고 이동
                if (Vector3.Distance(b.transform.position, b.originPos) > 1f)
                {
                    dir = (b.originPos - b.transform.position).normalized;
                    b.transform.forward = dir;
                    b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public void OperateExit(BossController b)
            {
                b.anim.SetBool("Move", false);
                b.transform.position = b.originPos;
                b.transform.rotation = b.originRot;
            }

            public IBossState InputHandle(BossController b)
            {
                if (Vector3.Distance(b.transform.position, b.originPos) < 1f)
                {
                    return b.dicState[BossState.Idle];
                }
                return this;
            }
        }

        public class StateDead : IBossState
        {
            float deadAnimDuration;
            float elapsedTime;

            public void OperateEnter(BossController b)
            {
                b.anim.SetBool("Dead", true);
                elapsedTime = 0f;
                deadAnimDuration = b.deadClip.length;
            }

            public void OperateUpdate(BossController b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(BossController b)
            {
            }

            public IBossState InputHandle(BossController b)
            {
                if (elapsedTime >= deadAnimDuration)
                {
                    PoolManager.Instance.Push(b.gameObject);
                }
                return this;
            }
        }
    }
}
