using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Assets.Scripts.Player;

public class Aim : MonoBehaviour
{
    static public Vector3 g_Aim = new Vector3();
    private bool g_AimLocked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlAimDirection();
        //MoveAim();
    }

    private void ControlAimDirection()
    {
        //I am so sorry for the one that is reading this aka probably Cisse. 
        //I know it's a cluster fuck but it works I think.... propably....
        //I've tried my best to put comments on everyting that explains the code good luck!!!!!
        AllKeyUps();
        AllKeyDowns();
        var angle = Mathf.Atan2(g_Aim.y,g_Aim.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void AllKeyDowns()
    {
        //1: right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            g_Aim.x = 1;
            g_Aim.y = 0;
        }//2: left
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            g_Aim.y = 0;
            g_Aim.x = -1;
        }
        //3,4,5: up or up right or up left
       else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            g_Aim.x = 0;
            g_Aim.y = 1;
        }//6,7,8: down or down right or down left
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            g_Aim.x = 0;
            g_Aim.y = -1;
        }
    }

    private void AllKeyUps()
    {
        ////Checking if you not aiming
        //if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    g_AimLocked = false;
        //    g_Aim.y = 0;
        //}

    }

    //this is only for testing puposes. The aim will start at the players location.
    //private void MoveAim()
    //{
    //    Vector3 move = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f);
    //    transform.position = move;
    //}

}
