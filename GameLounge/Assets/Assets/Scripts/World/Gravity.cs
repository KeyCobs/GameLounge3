using Assets.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{
    static public float g_Gravity = 20.8f;
    static public bool g_IsGravitySwitched = false;
    private float g_Time = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float setTime = 0.6f;
        if (Input.GetKeyDown(KeyCode.F) && (g_Time > setTime))
        {
            g_Gravity = -g_Gravity;
            g_IsGravitySwitched = true;
            g_Time = 0;
        }

        g_Time += Time.deltaTime;
    }

}

