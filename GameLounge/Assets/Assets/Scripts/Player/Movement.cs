using Assets.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charContr;
    static private Hero g_Hero = new Hero(5, 10);
    void Start()
    {
        charContr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            print(transform.position);
            transform.position = new Vector3(0.0f, 2, -1.0f);
            print(transform.position);
        }
        else
        {
        g_Hero.SetPlayerMovement(charContr);

        } 
    }
}

