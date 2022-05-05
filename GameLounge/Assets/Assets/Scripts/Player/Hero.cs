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
        static public int g_Speed { get; private set; }
        public Hero(int speed, int jumpSpeed)
        {
            Init(speed, jumpSpeed);
        }

        private void Init(int speed, int jumpSpeed)
        {
           
            g_Speed = speed;
            m_JumpSpeed = jumpSpeed;
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
        
        public int m_JumpSpeed { get; private set; }
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
            m_Move = StopMovingPlayer(m_Move,charcontr);
            m_Move = PlayerControl(charcontr);
            m_Move.y -= Gravity.g_Gravity * Time.deltaTime;
            charcontr.Move(m_Move * Time.deltaTime);
        }
        private Vector3 PlayerControl(CharacterController charcontr)
        {
            float setJumpTimer = 0.5f;
            //switch
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_Move.x = g_Speed;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_Move.x = -g_Speed;
            }
            if (Input.GetKeyDown(KeyCode.Space) && charcontr.isGrounded)
            {
                m_Move.y = m_JumpSpeed;
                m_TimeJump = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && m_TimeJump > setJumpTimer && Gravity.g_Gravity < 0)
            {
                m_Move.y = m_JumpSpeed;
                m_TimeJump = 0;
            }
            if (Gravity.g_IsGravitySwitched)
            {
                Vector3 rot = new Vector3(180.0f, 0.0f, 0.0f);
                m_JumpSpeed = -m_JumpSpeed;
                m_Move.y = 0;
                GameObject.Find("Player").transform.Rotate(rot); 
                m_TimeJump = -0.5f;
                Gravity.g_IsGravitySwitched = false;
            }




            m_Time += Time.deltaTime;
            m_TimeJump += Time.deltaTime;
            return m_Move;
        }
        private Vector3 StopMovingPlayer(Vector3 move, CharacterController charcontr)
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

            if (charcontr.isGrounded)
            {
                move.y = 0;
            }
            return move;
        }
        #endregion
    }
}