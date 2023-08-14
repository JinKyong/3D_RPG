using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace Character
{
    public partial class EnemyBoss : MonoBehaviour
    {
        public class IdleState : State<EnemyBoss>
        {
            float findDistance = 16f;

            public override void OperateEnter(EnemyBoss b)
            {
            }

            public override void OperateUpdate(EnemyBoss b)
            {
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.IsDamaged)
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

        public class ChaseState : State<EnemyBoss>
        {
            float AxeAtkDist = 2f;
            float roarAtkDist = 12f;
            float TornadoAtkDist = 5f;
            float returnDistance = 30f;
            float moveSpeed = 7f;
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Move", true);
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                // 플레이어 쪽으로 방향 틀고 이동(플레이어와 보스의 y축 높이값이 다르므로 맞춰줌)
                // dir은 월드 좌표고 translate은 로컬 좌표 기준으로 앞으로 움직이므로 같이 사용 불가
                dir = new Vector3 (b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("Move", false);
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.IsDamaged)
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
                else if (Vector3.Distance(b.originPos, b.transform.position) > returnDistance)
                {
                    return b.dicState[EnemyBossState.Return];
                }


                return this;
            }
        }

        public class AxeAtkState : State<EnemyBoss>
        {
            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("AxeAttack");
            }

            public override void OperateUpdate(EnemyBoss b)
            {
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.IsDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (b.anim.GetCurrentAnimatorStateInfo(0).IsName("Ork_AxeAttack") && b.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
                {
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class RoarAtkState : State<EnemyBoss>
        {
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("RoarAttack");
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                dir = new Vector3(b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
            }

            public override void OperateExit(EnemyBoss b)
            {        
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.IsDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (b.anim.GetCurrentAnimatorStateInfo(0).IsName("Ork_RoarAttack") && b.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
                {
                    return b.dicState[EnemyBossState.Chase];
                }

                return this;
            }
        }

        public class TornadoAtkState : State<EnemyBoss>
        {
            float elapsedTime;  
            float moveSpeed = 5f;
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {             
                b.anim.SetBool("TornadoAttack", true);
                elapsedTime = 0f;
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
                dir = new Vector3(b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("TornadoAttack", false);
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.IsDamaged)
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

        public class DamagedState : State<EnemyBoss>
        {
            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("Damaged");
            }

            public override void OperateUpdate(EnemyBoss b)
            {
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.hpSlider.value <= 0)
                {
                    b.bossDead.Raise();
                    return b.dicState[EnemyBossState.Dead];
                }
                else if (b.anim.GetCurrentAnimatorStateInfo(0).IsName("Ork_GetHit") && b.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
                {
                    b.IsDamaged = false;
                    return b.dicState[EnemyBossState.Idle];
                }

                return this;
            }
        }

        public class ReturnState : State<EnemyBoss>
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Move", true);
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                // 원래 위치로 방향 틀고 이동
                dir = (b.originPos - b.transform.position).normalized;
                b.transform.forward = dir;
                b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("Move", false);
                b.transform.position = b.originPos;
                b.transform.rotation = b.originRot;
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (Vector3.Distance(b.transform.position, b.originPos) < 0.5f)
                {
                    return b.dicState[EnemyBossState.Idle];
                }
                return this;
            }
        }

        public class DeadState : State<EnemyBoss>
        {
            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Dead", true);    
            }

            public override void OperateUpdate(EnemyBoss b)
            {
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.anim.GetCurrentAnimatorStateInfo(0).IsName("Dead") && b.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    PoolManager.Instance.Push(b.gameObject);
                }
                return this;
            }
        }
    }
}
