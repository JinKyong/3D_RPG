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

        public class ChaseState : State<EnemyBoss>
        {
            float AxeAtkDist = 2f;
            float roarAtkDist = 12f;
            float TornadoAtkDist = 10f;
            float returnDistance = 25f;
            float moveSpeed = 7f;
            Vector3 dir;

            AnimationClip clip;

            public override void OperateEnter(EnemyBoss b)
            {
                if (clip == null)
                {

                }

                b.anim.SetBool("Move", true);
                foreach (var c in b.anim.GetCurrentAnimatorClipInfo(0))
                    Debug.Log(c);

                

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
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
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

        public class AxeAtkState : State<EnemyBoss>
        {
            float atkAnimDuration;
            float elapsedTime;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("AxeAttack");
                b.leftAxe.enabled = true;
                b.rightAxe.enabled = true;
                elapsedTime = 0f;
                atkAnimDuration = b.axeAtkClip.length;
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.leftAxe.enabled = false;
                b.rightAxe.enabled = false;
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                // 애니메이션 너무 느려서 3배속 했으므로 클립의 시간/3
                else if (elapsedTime > atkAnimDuration/3)
                {
                    return b.dicState[EnemyBossState.Idle];
                }

                return this;
            }
        }

        public class RoarAtkState : State<EnemyBoss>
        {
            float atkAnimDuration;
            float elapsedTime;
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {
                atkAnimDuration = b.roarAtkClip.length;
                elapsedTime = 0f;
                dir = new Vector3(b.player.transform.position.x - b.transform.position.x, 0f, b.player.transform.position.z - b.transform.position.z).normalized;
                b.transform.forward = dir;
                b.anim.SetTrigger("RoarAttack");
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > atkAnimDuration / 3)
                {
                    b.flame.SetActive(true);
                    // Physics.OverlapBox
                }
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("RoarAttack", false);
                b.flame.SetActive(false);                    
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (elapsedTime > atkAnimDuration)
                {
                    return b.dicState[EnemyBossState.Idle];
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
                // 위치 변경
                b.tornado.gameObject.SetActive(true);
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
                b.tornado.gameObject.SetActive(false);
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (b.bDamaged)
                {
                    return b.dicState[EnemyBossState.Damaged];
                }
                else if (elapsedTime > 6f)
                {
                    return b.dicState[EnemyBossState.Idle];
                }

                return this;
            }
        }

        public class DamagedState : State<EnemyBoss>
        {
            float dmgAnimDuration;
            float elapsedTime;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = b.dmgClip.length;
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
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

        public class ReturnState : State<EnemyBoss>
        {
            float moveSpeed = 7f;
            Vector3 dir;

            public override void OperateEnter(EnemyBoss b)
            {
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                // 원래 위치로 방향 틀고 이동
                if (Vector3.Distance(b.transform.position, b.originPos) > 1f)
                {
                    dir = (b.originPos - b.transform.position).normalized;
                    b.transform.forward = dir;
                    b.rb.transform.position += dir * moveSpeed * Time.deltaTime;
                }
            }

            public override void OperateExit(EnemyBoss b)
            {
                b.anim.SetBool("Move", false);
                b.transform.position = b.originPos;
                b.transform.rotation = b.originRot;
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
            {
                if (Vector3.Distance(b.transform.position, b.originPos) < 1f)
                {
                    return b.dicState[EnemyBossState.Idle];
                }
                return this;
            }
        }

        public class DeadState : State<EnemyBoss>
        {
            float deadAnimDuration;
            float elapsedTime;

            public override void OperateEnter(EnemyBoss b)
            {
                b.anim.SetBool("Dead", true);
                elapsedTime = 0f;
                deadAnimDuration = b.deadClip.length;
            }

            public override void OperateUpdate(EnemyBoss b)
            {
                elapsedTime += Time.deltaTime;
            }

            public override void OperateExit(EnemyBoss b)
            {
            }

            public override State<EnemyBoss> InputHandle(EnemyBoss b)
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
