using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace State
{
    public partial class Enemy0 : MonoBehaviour
    {
        public class IdleState : IState<Enemy0>
        {
            float findDistance = 16f;
            public void OperateEnter(Enemy0 e)
            {
            }

            public void OperateUpdate(Enemy0 e)
            {
            }

            public void OperateExit(Enemy0 e)
            {
            }

            public IState<Enemy0> InputHandle(Enemy0 e)
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

        public class ChaseState : IState<Enemy0>
        {
            float atkDistance = 2f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(Enemy0 e)
            {
                e.anim.SetBool("RunForward", true);
            }

            public void OperateUpdate(Enemy0 e)
            {           
                // �÷��̾� ������ ���� Ʋ�� �̵�
                // dir�� ���� ��ǥ�� translate�� ���� ��ǥ �������� ������ �����̹Ƿ� ���� ��� �Ұ�
                dir = (e.player.transform.position - e.transform.position).normalized;
                e.transform.forward = dir;
                e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public void OperateExit(Enemy0 e)
            {
            }

            public IState<Enemy0> InputHandle(Enemy0 e)
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

        public class AttackState : IState<Enemy0>
        {
            float atkAnimDuration;
            float elapsedTime;

            public void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Attack");
                elapsedTime = 0f;
                atkAnimDuration = e.atkClip.length;
            }

            public void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(Enemy0 e)
            {
            }

            public IState<Enemy0> InputHandle(Enemy0 e)
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

        public class DamagedState : IState<Enemy0>
        {
            float dmgAnimDuration;
            float elapsedTime;

            public void OperateEnter(Enemy0 e)
            {
                e.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = e.dmgClip.length;
            }

            public void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(Enemy0 e)
            {
            }

            public IState<Enemy0> InputHandle(Enemy0 e)
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

        public class ReturnState : IState<Enemy0>
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(Enemy0 e)
            {
            }

            public void OperateUpdate(Enemy0 e)
            {
                // ���� ��ġ�� ���� Ʋ�� �̵�
                if (Vector3.Distance(e.transform.position, e.originPos) > 1f)
                {
                    dir = (e.originPos - e.transform.position).normalized;
                    e.transform.forward = dir;
                    e.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public void OperateExit(Enemy0 e)
            {
                e.anim.SetBool("RunForward", false);
                e.transform.position = e.originPos;
                e.transform.rotation = e.originRot;
            }

            public IState<Enemy0> InputHandle(Enemy0 e)
            {
                if (Vector3.Distance(e.transform.position, e.originPos) < 1f)                
                {
                    return e.dicState[EnemyState.Idle];
                }
                return this;
            }
        }

        public class DeadState : IState<Enemy0>
        {
            float deadAnimDuration;
            float elapsedTime;

            public void OperateEnter(Enemy0 e)
            {
                e.anim.SetBool("Dead", true);
                elapsedTime = 0f;                
                deadAnimDuration = e.deadClip.length;
            }

            public void OperateUpdate(Enemy0 e)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(Enemy0 e)
            {

            }

            public IState<Enemy0> InputHandle(Enemy0 e)
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
