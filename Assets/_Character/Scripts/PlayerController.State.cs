using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State
{
    public partial class PlayerController : MonoBehaviour
    {
        public class StateIdle : IState
        {
            public void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;

                p.anim.SetFloat("VelocityX", 0);
                p.anim.SetFloat("VelocityZ", 0);
            }

            public void OperateUpdate(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
            }

            public void OperateExit(PlayerController p)
            {                
            }

            public IState InputHandle(PlayerController p)
            {
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

                return this;
            }

        }

        public class StateRun : IState
        {
            float moveSpeed = 10f;

            public void OperateEnter(PlayerController p)
            {

            }

            public void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * moveSpeed * Time.deltaTime);
            }

            public void OperateExit(PlayerController p)
            {

            }

            public IState InputHandle(PlayerController p)
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

        public class StateJump : IState
        {
            float jumpPower = 6f;
            float jumpMoveSpeed = 6f;

            public void OperateEnter(PlayerController p)
            {
                p.anim.SetBool("Jump", true);
                // Forcemode.Impulse 는 순간적으로 힘을 주어 점프가 약간 더 자연스럽다고는 함
                p.rb.AddForce(new Vector3(0 , jumpPower, 0), ForceMode.Impulse);
            }

            public void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * jumpMoveSpeed * Time.deltaTime);
            }

            public void OperateExit(PlayerController p)
            {
   
            }

            public IState InputHandle(PlayerController p)
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

        public class StateFall : IState
        {
            float fallMoveSpeed = 6f;
            public void OperateEnter(PlayerController p)
            {
                Debug.Log(p.rb.velocity);
                p.anim.SetBool("Fall", true);
                Vector3 v = p.rb.velocity;
                v.y = -0.05f;
                p.rb.velocity = v;
            }

            public void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * fallMoveSpeed * Time.deltaTime);
            }

            public void OperateExit(PlayerController p)
            {
                p.anim.SetBool("Jump", false);
                p.anim.SetBool("Fall", false);
            }

            public IState InputHandle(PlayerController p)
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

        public class StateAttack : IState
        {    
            float atkAnimDuration;
            float elapsedTime;

            public void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.anim.SetFloat("VelocityX", 0);
                p.anim.SetFloat("VelocityZ", 0);
                p.anim.SetTrigger("Attack");
                elapsedTime = 0f;
                atkAnimDuration = p.atkClip.length;
            }

            public void OperateUpdate(PlayerController p)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(PlayerController p)
            {

            }

            public IState InputHandle(PlayerController p)
            {
                if (p.bDamaged)
                {
                    return p.dicState[PlayerState.Damaged];
                }
                // 공격 후 기본상태로 돌아가는 딜레이를 줄이기 위해 atkAnimDuration(1.9f) 에서 0.6f 정도 빼줌
                else if (elapsedTime >= atkAnimDuration - 0.6f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class StateDamaged : IState
        {
            float dmgAnimDuration;
            float elapsedTime;

            public void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
                p.anim.SetTrigger("Damaged");
                elapsedTime = 0f;
                dmgAnimDuration = p.dmgClip.length;
            }

            public void OperateUpdate(PlayerController p)
            {
                elapsedTime += Time.deltaTime;
            }

            public void OperateExit(PlayerController p)
            {
            }

            public IState InputHandle(PlayerController p)
            {
                if (p.hpSlider.value <= 0)
                {
                    return p.dicState[PlayerState.Dead];
                }
                else if (elapsedTime >= dmgAnimDuration)
                {
                    p.bDamaged = false;
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }
        public class StateDead : IState
        {
            public void OperateEnter(PlayerController p)
            {
                p.rb.velocity = Vector3.zero;
            }

            public void OperateUpdate(PlayerController p)
            {
            }

            public void OperateExit(PlayerController p)
            {
            }

            public IState InputHandle(PlayerController p)
            {
                return this;
            }
        }

    }
}
