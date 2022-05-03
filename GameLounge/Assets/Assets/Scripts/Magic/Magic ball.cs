using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicball
{
    //public
    public Magicball(Vector3 speed, Material myMaterial)
    {
        Init(speed, myMaterial);
    }
    private void Init(Vector3 speed, Material myMaterial)
    {
        m_Position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f);
        m_Speed = speed;
        m_IsActive = true;
        CreateMagicBall(myMaterial);
    }
    private void CreateMagicBall(Material myMaterial)
    {
        Vector3[] vertices = {
            new Vector3 (0, 0, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
        };

        int[] triangles = {
            0, 2, 1, //face front
			0, 3, 2,
            2, 3, 4, //face top
			2, 4, 5,
            1, 2, 5, //face right
			1, 5, 6,
            0, 7, 4, //face left
			0, 4, 3,
            5, 4, 7, //face back
			5, 7, 6,
            0, 6, 7, //face bottom
			0, 1, 6
        };

        m_MagicBall = new GameObject();
        //m_MagicBall.tag = "Objects";
        Mesh m = new Mesh();
        m.Clear();
        m.vertices = vertices;
        m.triangles = triangles;
        m.Optimize();
        m.RecalculateNormals();

        m_MagicBall.AddComponent<MeshRenderer>();
        m_MagicBall.AddComponent<MeshFilter>().mesh = m;
        m_MagicBall.GetComponent<MeshRenderer>().material = myMaterial;//.GetTexture("MagicBall");// = Resources.Load("Assets/Assets/Sprites/Keycobs_Test/Materials/MagicBall.mat", typeof(Material)) as Material;
    }
    public enum MagicType
    {
        FireBall
    }
    public void Movement()
    {
        m_Position += m_Speed;
        m_MagicBall.transform.position = m_Position; 
    }
    public void DestroyMagicBall()
    {
        GameObject.Destroy(m_MagicBall);
    }

    //Collision detection
    //Movement
    //MaxRangeToPlayer
    public GameObject m_MagicBall;
    public MagicType m_Type { get; private set; }
    public Vector3 m_Position { get; private set; }
    public bool m_IsActive { get; private set; }
    public int m_ManaCost { get; private set; }

    //private
    private Vector3 m_Speed;
    


}
