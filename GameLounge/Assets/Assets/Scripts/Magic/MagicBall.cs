using Assets.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    //public
    public void Init()
    {
        m_Speed.x = Aim.g_Aim.x * 6 * Time.deltaTime;
        m_Speed.y = Aim.g_Aim.y * 6 * Time.deltaTime;
        //m_PrefabBall = prefab; //prefebBall mag weg
        m_Position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f);
        m_IsActive = true;
        //CreateMagicBall(myMaterial);
    }
    private void CreateMagicBall(Material myMaterial)
    {


        //m_MagicBall = Instantiate(m_PrefabBall, m_Position, Quaternion.identity); //prefab in de wereld spawnen met pos en rot in magicball


        //Mesh m = new Mesh();
        //m.Clear();
        //m.vertices = vertices;
        //m.triangles = triangles;
        //m.Optimize();
        //m.RecalculateNormals();

        #region addComponent&GetComponent
        //m_MagicBall.layer = 3;
        //m_MagicBall.AddComponent<MeshRenderer>();
        //m_MagicBall.AddComponent<Rigidbody>();
        //m_MagicBall.AddComponent<BoxCollider>();
        //m_MagicBall.AddComponent<MeshFilter>().mesh = m;
        //m_MagicBall.GetComponent<MeshRenderer>().material = myMaterial; 
        //m_MagicBall.GetComponent<BoxCollider>().isTrigger = true;
        //m_MagicBall.GetComponent<Rigidbody>().detectCollisions = true;
        //m_MagicBall.GetComponent<Rigidbody>().isKinematic = false;
        //m_MagicBall.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        #endregion
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
