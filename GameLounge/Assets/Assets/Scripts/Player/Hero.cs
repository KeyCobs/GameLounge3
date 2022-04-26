using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Assets.Scripts.Player
{
    internal class Hero : MonoBehaviour
    {
        public Hero(int speed, int jumpSpeed, float gravity)
        {
            Init(speed, jumpSpeed, gravity);
        }

        private void Init(int speed, int jumpSpeed, float gravity)
        {
            m_Speed = speed;
            m_JumpSpeed = jumpSpeed;
            m_Gravity = gravity;
            m_Time = 0;
            m_TimeJump = 0;

            m_Move = new Vector3();
        }

        enum HeroState
        {
            Walking,
            Running,
            Jumping
        }
        //public
        public int m_Speed { get; private set; }
        public int m_JumpSpeed { get; private set; }
        private float m_Gravity;
        private float m_Time;
        private float m_TimeJump;
        private Vector3 m_Move;
        //Todo
        public int m_HP;
        //public Gun m_Gun;


        //private
        private string m_Texture;

        #region PlayerMovement
        public void SetPlayerMovement(CharacterController charcontr)
        {
            m_Move = StopMovingPlayer(m_Move);
            m_Move = PlayerControl(charcontr);
            m_Move.y -= m_Gravity * Time.deltaTime;
            charcontr.Move(m_Move * Time.deltaTime);
        }
        private Vector3 PlayerControl(CharacterController charcontr)
        {
            float setTime = 0.6f;
            float setJumpTimer = 0.5f;
            //switch
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_Move.x = m_Speed;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_Move.x = -m_Speed;
            }
            if (Input.GetKeyDown(KeyCode.Space) && charcontr.isGrounded)
            {
                m_Move.y = m_JumpSpeed;
                m_TimeJump = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space) && m_TimeJump > setJumpTimer && m_Gravity < 0)
            {
                m_Move.y = m_JumpSpeed;
                m_TimeJump = 0;
            }
            if (Input.GetKeyDown(KeyCode.F) && (m_Time > setTime))
            {
                Vector3 rot = new Vector3(180.0f, 0.0f, 0.0f) { };
                m_Gravity = -m_Gravity;
                m_JumpSpeed = -m_JumpSpeed;
                m_Move.y = 0;
                m_Time = 0;
                transform.Rotate(rot);
                m_TimeJump = -0.5f;
            }

            m_Time += Time.deltaTime;
            m_TimeJump += Time.deltaTime;
            print(m_Move.y);
            return m_Move;
        }
        private Vector3 StopMovingPlayer(Vector3 move)
        {

            bool stopHorizontal = ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)));
            if (stopHorizontal)
            {
                move.x = 0;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                move.z = 0;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                move.z = 0;
            }
            return move;
        }
        #endregion
    }
}