using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace State
{
    public partial class EnemyBoss : MonoBehaviour
    {
        public class IdleState : IState<EnemyBoss>
        {
            float findDistance = 16f;
            public void OperateEnter(EnemyBoss b)
            {
            }

            public void OperateUpdate(EnemyBoss b)
            {
            }

            public void OperateExit(EnemyBoss b)
            {
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (Vector3.Distance(b.transform.position, b.player.transform.position) < findDistance)
                {
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class ChaseState : IState<EnemyBoss>
        {
            float AxeAtkDist = 2f;
            float roarAtkDist = 12f;
            float TornadoAtkDist = 10f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Move", true);
            }

            public void OperateUpdate(EnemyBoss b)
            {
                // �÷��̾� ������ ���� Ʋ�� �̵�(�÷��̾�� ������ y�� ���̰��� �ٸ��Ƿ� ������)
                // dir�� ���� ��ǥ�� translate�� ���� ��ǥ �������� ������ �����̹Ƿ� ���� ��� �Ұ�
                dir = new Vector3 (b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public void OperateExit(EnemyBoss b)
            { 
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (b.hpSlider.value <= 0.25f && Vector3.Distance(b.player.transform.position, b.transform.position) < TornadoAtkDist)
                {
                    return b.dicState[EnemyBossState.Attack3];
                }
                else if (b.hpSlider.value <= 0.5f && Vector3.Distance(b.player.transform.position, b.transform.position) < roarAtkDist)
                {
                    return b.dicState[EnemyBossState.Attack2];
                }
                else if (Vector3.Distance(b.player.transform.position, b.transform.position) < AxeAtkDist)
                {
                    return b.dicState[EnemyBossState.Attack1];
                }
                else if (Vector3.Distance(b.player.transform.position, b.transform.position) > returnDistance)
                {
                    return b.dicState[EnemyBossState.Return];
                }


                return this;
            }
        }

        public class AxeAtkState : IState<EnemyBoss>
        {
            float atkAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("AxeAttack");
                elapsedTime = 0f;
                atkAnimDuration = b.axeAtkClip.length;
            }

            public void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyBoss b)
            {
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                // �ִϸ��̼� �ʹ� ������ 3��� �����Ƿ� Ŭ���� �ð�/3
                else if (elapsedTime > atkAnimDuration/3)
                {
                    return b.dicState[EnemyBossState.Chase];
                }


                return this;
            }
        }

        public class RoarAtkState : IState<EnemyBoss>
        {
            float atkAnimDuration;
            float elapsedTime;
            Vector3 dir;

            public void OperateEnter(EnemyBoss b)
            {
                atkAnimDuration = b.roarAtkClip.length;
                elapsedTime = 0f;
                dir = new Vector3(b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.anim.SetTrigger("RoarAttack");
            }

            public void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > atkAnimDuration / 3)
                {
                    b.flame.SetActive(true);
                }
            }

            public void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("RoarAttack", false);
                b.flame.SetActive(false);                    
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (elapsedTime > atkAnimDuration)
                {
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class TornadoAtkState : IState<EnemyBoss>
        {
            float elapsedTime;  
            float moveSpeed = 5f;
            Vector3 dir;

            public void OperateEnter(EnemyBoss b)
            {             
                b.anim.SetBool("TornadoAttack", true);
                elapsedTime = 0f;                
                // ��ġ ����
                b.tornado.gameObject.SetActive(true);
            }

            public void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
                dir = new Vector3(b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("TornadoAttack", false);
                b.tornado.gameObject.SetActive(false);
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (elapsedTime > 6f)
                {
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class DamagedState : IState<EnemyBoss>
        {
            float dmgAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = b.dmgClip.length;
            }

            public void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyBoss b)
            {
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.hpSlider.value <= 0)
                {
                    return b.dicState[EnemyBossState.Dead];
                }
                else if (elapsedTime >= dmgAnimDuration)
                {
                    b.bDamaged = false;
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class ReturnState : IState<EnemyBoss>
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public void OperateEnter(EnemyBoss b)
            {
            }

            public void OperateUpdate(EnemyBoss b)
            {
                // ���� ��ġ�� ���� Ʋ�� �̵�
                if (Vector3.Distance(b.transform.position, b.originPos) > 1f)
                {
                    dir = (b.originPos - b.transform.position).normalized;
                    b.transform.forward = dir;
                    b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("Move", false);
                b.transform.position = b.originPos;
                b.transform.rotation = b.originRot;
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (Vector3.Distance(b.transform.position, b.originPos) < 1f)
                {
                    return b.dicState[EnemyBossState.Idle];
                }
                return this;
            }
        }

        public class DeadState : IState<EnemyBoss>
        {
            float deadAnimDuration;
            float elapsedTime;

            public void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Dead", true);
                elapsedTime = 0f;
                deadAnimDuration = b.deadClip.length;
            }

            public void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(EnemyBoss b)
            {
            }

            public IState<EnemyBoss> InputHandle(EnemyBoss b)
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
