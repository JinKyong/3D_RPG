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

                p.ani.SetFloat("VelocityX", 0);
                p.ani.SetFloat("VelocityZ", 0);

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

                if (p.jumpInput())
                {
                    return p.dicState[PlayerState.Jump];
                }

                if (Input.GetMouseButtonDown(0))
                {
                    return p.dicState[PlayerState.Attack];
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
                p.moveInput();

                //p.dir = Camera.main.transform.TransformDirection(p.dir);
                p.dir.Normalize();
                // ����
                p.rb.transform.forward = Camera.main.transform.forward;
                    //new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                Debug.Log(p.rb.transform.forward);
                

                // �Ϲ� �̵��� y�� ���� �̼��ϰ� ������


                if (p.dir == Vector3.zero)
                    return p.dicState[PlayerState.Idle];

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return p.dicState[PlayerState.Jump];
                }

                if (Input.GetMouseButtonDown(0))
                {
                    return p.dicState[PlayerState.Attack];
                }

                return this;
            }
        }

        public class StateJump : IState
        {
            float jumpPower = 5f;
            float jumpMoveSpeed = 5f;

            public void OperateEnter(PlayerController p)
            {
                p.ani.SetBool("bJump", true);
                p.bGround = false;
                //���Ⱚ�� �޾Ƽ� 
                //jumpDir = p.rb.velocity.normalized;
                // Forcemode.Impulse �� ���������� ���� �־� ������ �ణ �� �ڿ������ٰ�� ��
                p.rb.AddForce(new Vector3(0 , jumpPower, 0), ForceMode.Impulse);
            }

            public void OperateUpdate(PlayerController p)
            {
                p.rb.transform.Translate(p.dir * jumpMoveSpeed * Time.deltaTime);
            }

            public void OperateExit(PlayerController p)
            {
                //p.ani.SetBool("bJump", false);
            }

            public IState InputHandle(PlayerController p)
            {
                //moveInput �Լ����ֱ�
                float v = Input.GetAxis("Vertical");

                Vector3 dir = p.dir;
                dir.z = v;
                p.dir = dir;


                if (p.rb.velocity.y < -0.03f)
                {
                    return p.dicState[PlayerState.Fall];
                }

                return this;
            }
        }

        public class StateFall : IState
        {
            public void OperateEnter(PlayerController p)
            {
                Debug.Log(p.rb.velocity);
                p.ani.SetBool("bFall", true);
                Vector3 v = p.rb.velocity;
                v.y = -0.05f;
                p.rb.velocity = v;
                //p.ani.SetBool("bJump", true);
            }

            public void OperateUpdate(PlayerController p)
            {
                
            }

            public void OperateExit(PlayerController p)
            {
                p.ani.SetBool("bJump", false);
                p.ani.SetBool("bFall", false);
            }

            public IState InputHandle(PlayerController p)
            {
                //������ȯ�ϴ� ���� �Ǻ� enemy ���� ��� distance check
                // �����ö��� ���� �յ�
                if (p.rb.velocity.y > -0.03f)
                {
                    return p.dicState[PlayerState.Idle];
                }

                return this;
            }
        }

        public class StateAttack : IState
        {    
            private float atkAnimDuration;
            private float elapsedTime;

            public void OperateEnter(PlayerController p)
            {
                p.ani.SetTrigger("tAtk");
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
                if (elapsedTime >= atkAnimDuration)
                {
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
                throw new System.NotImplementedException();
            }

            public void OperateExit(PlayerController p)
            {
                throw new System.NotImplementedException();
            }

            public IState InputHandle(PlayerController p)
            {
                throw new System.NotImplementedException();
            }
        }

    }
}
