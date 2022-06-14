using Assets.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 m_StartPosPlayer = GameObject.Find("Player").transform.position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = m_StartPosPlayer - GameObject.Find("Player").transform.position;
        
        //move left
        if (camPos.x > (m_StartPosPlayer.x + 5))
        {
            Vector3 v = new Vector3( -0.1f, 0.0f, 0.0f );
            GameObject.Find("Main Camera").transform.position += v;
        }   
    }
}
