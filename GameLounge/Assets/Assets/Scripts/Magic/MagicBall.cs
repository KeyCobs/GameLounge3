using Assets.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    //public
    public void Init()
    {
        m_Speed.x = Aim.g_Aim.x * 10 * Time.deltaTime;
        m_Speed.y = Aim.g_Aim.y * 10 * Time.deltaTime;
        //m_PrefabBall = prefab; //prefebBall mag weg
        m_Position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f);
        m_IsActive = true;
        //CreateMagicBall(myMaterial);
    }

    public enum MagicType
    {
        FireBall
    }
    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected");
        if (collision.gameObject.tag == "Object")
        {
            m_IsActive = false;
        }
    }

    
    public void Update()
    {
        m_Position += m_Speed;
        m_MagicBall.transform.position = m_Position; 
    }




    //Collision detection
    //MaxRangeToPlayer
    public GameObject m_MagicBall;
    public MagicType m_Type { get; private set; }
    public Vector3 m_Position { get; private set; }
    public bool m_IsActive { get; private set; }
    public int m_ManaCost { get; private set; }
    

    //private
    private Vector3 m_Speed;
    


}
