using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.State
{
    public partial class PlayerController : MonoBehaviour
    {
        public class IdleState : State<PlayerController>
        {
            public override void OperateEnter(PlayerController p)
            {
                p.anim.SetFloat("VelocityX", 0);
                p.anim.SetFloat("VelocityZ", 0);
            }

            public override void OperateUpdate(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
            }

            public override void OperateExit(PlayerController p)
            {                
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return p.dicState[PlayerState.test];
                }

                if (p.moveInput())
                {
                    return p.dicState[PlayerState.Run];
                }
                else if (p.jumpInput())
                {
                    return p.dicState[PlayerState.Jump];
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    return p.dicState[PlayerState.Attack];
                }   
                else if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    return p.dicState[PlayerState.Skill1];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    return p.dicState[PlayerState.Skill2];
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    return p.dicState[PlayerState.Skill3];
                }

                return this;
            }
        }

        public class RunState : State<PlayerController>
        {
            float moveSpeed = 10f;

            public override void OperateEnter(PlayerController p)
            {

            }

            public override void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * moveSpeed * Time.deltaTime);
            }

            public override void OperateExit(PlayerController p)
            {

            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                p.anim.SetFloat("VelocityX", h);
                p.anim.SetFloat("VelocityZ", v);

                p.dir = new Vector3(h, 0, v);
                p.dir.Normalize();
                p.rb.transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

                if (p.dir == Vector3.zero)
                {
                    return p.dicState[PlayerState.Idle];                
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    return p.dicState[PlayerState.Jump];
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    return p.dicState[PlayerState.Attack];
                }
                else if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }

                return this;
            }
        }

        public class JumpState : State<PlayerController>
        {
            float jumpPower = 6f;
            float jumpMoveSpeed = 6f;

            public override void OperateEnter(PlayerController p)
            {
                p.anim.SetBool("Jump", true);
                // Forcemode.Impulse 는 순간적으로 힘을 주어 점프가 약간 더 자연스럽다고는 함
                p.rb.AddForce(new Vector3(0 , jumpPower, 0), ForceMode.Impulse);
            }

            public override void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * jumpMoveSpeed * Time.deltaTime);
            }

            public override void OperateExit(PlayerController p)
            {
   
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {  
                float v = Input.GetAxis("Vertical");

                Vector3 dir = p.dir;
                dir.z = v;
                p.dir = dir;

                if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                else if (p.rb.velocity.y < -0.03f)
                {
                    return p.dicState[PlayerState.Fall];
                }

                return this;
            }
        }

        public class FallState : State<PlayerController>
        {
            float fallMoveSpeed = 6f;
            public override void OperateEnter(PlayerController p)
            {
                p.anim.SetBool("Fall", true);
                Vector3 v = p.rb.velocity;
                v.y = -0.05f;
                p.rb.velocity = v;
            }

            public override void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * fallMoveSpeed * Time.deltaTime);
            }

            public override void OperateExit(PlayerController p)
            {
                p.anim.SetBool("Jump", false);
                p.anim.SetBool("Fall", false);
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                float v = Input.GetAxis("Vertical");

                Vector3 dir = p.dir;
                dir.z = v;
                p.dir = dir;

                if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                else if (p.rb.velocity.y > -0.03f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class AttackState : State<PlayerController>
        {        

            public override void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.anim.SetFloat("VelocityX", 0);
                p.anim.SetFloat("VelocityZ", 0);
                p.anim.SetTrigger("Attack");    
            }

            public override void OperateUpdate(PlayerController p)
            { 
            }

            public override void OperateExit(PlayerController p)
            {
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                else if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class TestSkillState : State<PlayerController>
        {
            public override State<PlayerController> InputHandle(PlayerController t)
            {
                return this;
            }

            public override void OperateEnter(PlayerController t)
            {
                Debug.Log(t.testState.name);
                Debug.Log(t.testClip);
                t.controller.SetStateEffectiveMotion(t.testState, t.testClip);
                t.anim.SetBool("testSkill", true);
            }

            public override void OperateExit(PlayerController t)
            {
            }

            public override void OperateUpdate(PlayerController t)
            {
            }
        }

        public class Skill1State : State<PlayerController>
        {
            public override void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.anim.SetTrigger("Skill1");
                p.mp -= 20;
            }

            public override void OperateUpdate(PlayerController p)
            {
            }

            public override void OperateExit(PlayerController p)
            {                
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                // 소환 애니메이션 끝나면 particleSystem 위치시키기
                // normalized 최대값이 1이 아니라 보간정도에 따라 다를 수 있다고함
                else if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Skill1")
                    && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75f)
                {
/*                    Vector3 pos = new Vector3 (p.transform.position.x + Camera.main.transform.forward.x * 20f,
                        0f,
                        p.transform.position.z + Camera.main.transform.forward.z * 20f);*/

                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class Skill2State : State<PlayerController>
        {
            // Character.Ability.Data.SkillData 에서 데미지 받아서
            public override void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.anim.SetTrigger("Skill2");
                p.mp -= 10;
            }

            public override void OperateUpdate(PlayerController p)
            {
                if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Skill2") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
                {
                    p.skill2.gameObject.SetActive(true);
                }


                Debug.Log(p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

            }

            public override void OperateExit(PlayerController p)
            {
                p.skill2.gameObject.SetActive(false);
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Skill2") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }


        public class Skill3State : State<PlayerController>
        {
            float moveSpeed = 2f;

            public override void OperateEnter(PlayerController p)
            {
                p.anim.SetTrigger("Skill3");
                p.mp -= 10;
            }

            public override void OperateUpdate(PlayerController p)
            {
                if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Skill3") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f)
                {
                    p.rb.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
            }

            public override void OperateExit(PlayerController p)
            {
                p.skill3.gameObject.SetActive(false);
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Skill3") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class DamagedState : State<PlayerController>
        {

            public override void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.hp -= p.damaged;
                p.anim.SetTrigger("Damaged");
                // p.gameObject.layer = LayerMask.NameToLayer("PlayerDamaged");
            }

            public override void OperateUpdate(PlayerController p)
            {
            }

            public override void OperateExit(PlayerController p)
            {
                // p.gameObject.layer = LayerMask.NameToLayer("Player");
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                if (p.hpSlider.value <= 0)
                {
                    return p.dicState[PlayerState.Dead];
                }
                else if (p.anim.GetCurrentAnimatorStateInfo(0).IsName("Damaged") && p.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
                {
                    p.bDamaged = false;
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }
        public class DeadState : State<PlayerController>
        {
            public override void OperateEnter(PlayerController p)
            {
                p.anim.SetBool("Dead", true);
                p.rb.velocity = Vector3.zero;
            }

            public override void OperateUpdate(PlayerController p)
            {
            }

            public override void OperateExit(PlayerController p)
            {
            }

            public override State<PlayerController> InputHandle(PlayerController p)
            {
                return this;
            }
        }
    }
}
