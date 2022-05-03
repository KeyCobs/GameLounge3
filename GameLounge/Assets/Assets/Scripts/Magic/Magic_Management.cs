using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Management : MonoBehaviour
{
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
            CreateMagicBall();
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
            if (!elem.m_IsActive || Input.GetKeyDown(KeyCode.V))
            {
                print(g_ListOfMagicBalls.Count);
                DestroyMagicBall(g_ListOfMagicBalls.IndexOf(elem));
                print(g_ListOfMagicBalls.Count);
            }
        }
    }
    private void CreateMagicBall()
    {
        print("Magic ball created");
        Vector3 mousePos = Input.mousePosition;
        Magicball mb = new Magicball(mousePos);
        g_ListOfMagicBalls.Add(mb);
    }
    private void DestroyMagicBall(int indx)
    {
        print("Magic ball destroyed");
        g_ListOfMagicBalls[indx].DestroyMagicBall();
        g_ListOfMagicBalls.RemoveAt(indx);
    }
}
