using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charContr;
    [SerializeField]
    float g_Gravity = 9.8f;
    float g_Speed = 50;
    float g_JumpSpeed = 65;

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

        //var hor = Input.GetAxis("Horzintal");
        //var ver = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(hor, g_Move.y, ver) * g_Speed * Time.deltaTime);

        //if (charContr.isGrounded)
        //{
        //    g_Move = new Vector3(hor,0.0f,ver);
        //    g_Move *= g_Speed;

        //    if (Input.GetButton("Jump"))
        //    {
        //        g_Move.y = g_JumpSpeed;
        //    }
        //}

        if (charContr.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                g_Move.x = g_Speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                g_Move.z = g_Speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                g_Move.z = -g_Speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                g_Move.x = -g_Speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                g_Move.y = g_JumpSpeed * Time.deltaTime;
            }
        }



        g_Move.y -= g_Gravity * Time.deltaTime;
        charContr.Move(g_Move * Time.deltaTime);
    }
}
