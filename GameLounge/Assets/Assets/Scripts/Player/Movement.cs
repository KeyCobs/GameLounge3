using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charContr;
    [SerializeField]
    public float g_Gravity = 9.8f;
    public float g_Speed = 5;
    public float g_JumpSpeed = 10;
    float g_Time = 0;
    float g_TimeJump = 0;
    private Vector3 g_Move = new Vector3();
    void Start()
    {
        charContr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {

        g_Move = StopMovingPlayer(g_Move);
        g_Move = MovePlayer(g_Move);
        g_Move.y -= g_Gravity * Time.deltaTime;
        charContr.Move(g_Move * Time.deltaTime);
    }

    private Vector3 MovePlayer(Vector3 move)
    {
        float setTime = 0.6f;
        float setJumpTimer = 0.5f;
        //switch
        if (Input.GetKeyDown(KeyCode.D))
        {
            move.x = g_Speed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move.z = g_Speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move.z = -g_Speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move.x = -g_Speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && charContr.isGrounded)
        {
            move.y = g_JumpSpeed;
            g_TimeJump = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && g_TimeJump > setJumpTimer && g_Gravity < 0)
        {
            move.y = g_JumpSpeed;
            g_TimeJump = 0;
        }
        if (Input.GetKeyDown(KeyCode.F) && (g_Time > setTime))
        {
            Vector3 rot = new Vector3(180.0f,0.0f,0.0f) { };
            g_Gravity = -g_Gravity;
            g_JumpSpeed = -g_JumpSpeed;
            move.y = 0;
            g_Time = 0;
            transform.Rotate(rot);
            g_TimeJump = -0.5f;
        }



        g_Time += Time.deltaTime;
        g_TimeJump += Time.deltaTime;
        print(move.y);
        return move;
    }

    private Vector3 StopMovingPlayer(Vector3 move)
    {

        bool stopHorizontal = ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) ||( Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)));
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
}
