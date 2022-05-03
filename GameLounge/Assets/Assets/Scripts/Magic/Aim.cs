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

    }

    private void ControlAimDirection()
    {

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            g_Aim.y = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            g_AimLocked = false;
        }

        if (!g_AimLocked)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                g_Aim.x = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                g_Aim.x = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            g_AimLocked = true;
            g_Aim.x = 1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                g_AimLocked = true;
                g_Aim.y = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            g_AimLocked = true;
            g_Aim.x = -1;

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                g_AimLocked = true;
                g_Aim.y = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            g_AimLocked = true;
            g_Aim.y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            g_AimLocked = true;
            g_Aim.y = -1;
        }




        var angle = Mathf.Atan2(g_Aim.y,g_Aim.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
