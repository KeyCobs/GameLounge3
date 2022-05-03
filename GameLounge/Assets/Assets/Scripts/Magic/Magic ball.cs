using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicball
{
    //public
    public Magicball(Vector3 speed)
    {
        Init(speed);
    }
    private void Init(Vector3 speed)
    {
        m_Speed = speed;
        m_MagicBall = new GameObject();
        m_IsActive = true;
    }
    public enum MagicType
    {
        FireBall
    }
    public Vector3 Movement()
    {
        return m_Position += m_Speed;
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
