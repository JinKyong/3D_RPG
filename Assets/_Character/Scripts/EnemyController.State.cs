using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy.State
{
    public partial class EnemyController : MonoBehaviour
    {
        public class StateIdle : IEnemyState
        {
            float findDistance = 16f;
            public void OperateEnter(EnemyController e)
            {
            }

            public void OperateUpdate(EnemyController e)
            {
            }

            public void OperateExit(EnemyController e)
            {
            }

            public IEnemyState InputHandle(EnemyController e)
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

        public class StateMove : IEnemyState
        {
            float atkDistance = 2f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(EnemyController e)
            {
                e.anim.SetBool("RunForward", true);
            }

            public void OperateUpdate(EnemyController e)
            {           
                // 플레이어 쪽으로 방향 틀고 이동
                // dir은 월드 좌표고 translate은 로컬 좌표 기준으로 앞으로 움직이므로 같이 사용 불가
                dir = (e.player.transform.position - e.transform.position).normalized;
                e.transform.forward = dir;
                e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public void OperateExit(EnemyController e)
            {
            }

            public IEnemyState InputHandle(EnemyController e)
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

        public class StateAttack : IEnemyState
        {
            float atkAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyController e)
            {
                e.anim.SetTrigger("Attack");
                elapsedTime = 0f;
                atkAnimDuration = e.atkClip.length;
            }

            public void OperateUpdate(EnemyController e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyController e)
            {
            }

            public IEnemyState InputHandle(EnemyController e)
            {
                if (elapsedTime >= atkAnimDuration)
                {
                    return e.dicState[EnemyState.Idle];
                }

                if (e.bDamaged)
                {
                    return e.dicState[EnemyState.Damaged];
                }

                return this;
            }
        }

        public class StateDamaged : IEnemyState
        {
            float dmgAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyController e)
            {
                e.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = e.dmgClip.length;
            }

            public void OperateUpdate(EnemyController e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyController e)
            {
            }

            public IEnemyState InputHandle(EnemyController e)
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

        public class StateReturn : IEnemyState
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(EnemyController e)
            {
            }

            public void OperateUpdate(EnemyController e)
            {
                // 원래 위치로 방향 틀고 이동
                if (Vector3.Distance(e.transform.position, e.originPos) > 1f)
                {
                    dir = (e.originPos - e.transform.position).normalized;
                    e.transform.forward = dir;
                    e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public void OperateExit(EnemyController e)
            {
                e.anim.SetBool("RunForward", false);
                e.transform.position = e.originPos;
                e.transform.rotation = e.originRot;
            }

            public IEnemyState InputHandle(EnemyController e)
            {
                if (Vector3.Distance(e.transform.position, e.originPos) < 1f)                
                {
                    return e.dicState[EnemyState.Idle];
                }
                return this;
            }
        }

        public class StateDead : IEnemyState
        {
            float deadAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyController e)
            {
                e.anim.SetBool("Dead", true);
                elapsedTime = 0f;
                deadAnimDuration = e.deadClip.length;
            }

            public void OperateUpdate(EnemyController e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyController e)
            {
            }

            public IEnemyState InputHandle(EnemyController e)
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
