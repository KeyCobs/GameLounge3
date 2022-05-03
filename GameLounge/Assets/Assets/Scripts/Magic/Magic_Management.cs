using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Management : MonoBehaviour
{
    [SerializeField]
    public Material myMaterial;

    List<Magicball> g_ListOfMagicBalls;
    // Start is called before the first frame update
    void Start()
    {
        g_ListOfMagicBalls = new List<Magicball>();
    }

    // Update is called once per frame
    void Update()
    {
        //time still need to multiply on movement
        if (Input.GetMouseButtonUp(0))
        {
            print("Create");
            CreateMagicBall(myMaterial);
        }
        UpdateMagicBall();
    }
    private void UpdateMagicBall()
    {
        //return if list is empty
        if (g_ListOfMagicBalls.Count == 0) return;

        foreach (var elem in g_ListOfMagicBalls)
        {
            elem.Movement();
            //Check if magic is still active
            if (!elem.m_IsActive || Input.GetKeyDown(KeyCode.V))
            {
                print(g_ListOfMagicBalls.Count);
                DestroyMagicBall(g_ListOfMagicBalls.IndexOf(elem));
                print(g_ListOfMagicBalls.Count);
            }
        }
    }
    private void CreateMagicBall(Material myMaterial)
    {
        //Calculating speed for the magicballs
        Vector3 speed = Aim.g_Aim;
        speed.x *= 6 * Time.deltaTime;
        speed.y *= 6 * Time.deltaTime;
        Magicball mb = new Magicball(speed, myMaterial);
        g_ListOfMagicBalls.Add(mb);
    }
    private void DestroyMagicBall(int indx)
    {
        print("Magic ball destroyed");
        g_ListOfMagicBalls[indx].DestroyMagicBall();
        g_ListOfMagicBalls.RemoveAt(indx);
    }
}
