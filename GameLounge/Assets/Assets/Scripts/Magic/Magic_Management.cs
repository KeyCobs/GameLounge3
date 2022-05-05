using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Management : MonoBehaviour
{
    [SerializeField]
    public Material myMaterial;
    public GameObject myPrefab;

    List<GameObject> g_ListOfMagicBalls; //change G into M
    // Start is called before the first frame update
    void Start()
    {
        g_ListOfMagicBalls = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        //time still need to multiply on movement
        if (Input.GetMouseButtonUp(0))
        {
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

            //elem.Movement();
            //Check if magic is still active
            if (!elem.GetComponent<MagicBall>().m_IsActive)
            {
                print(g_ListOfMagicBalls.Count);
                DestroyMagicBall(g_ListOfMagicBalls.IndexOf(elem));
            }
        }
    }
    private void CreateMagicBall(Material myMaterial)
    {
        //Calculating speed for the magicballs

        GameObject ob = Instantiate(myPrefab,new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f), Quaternion.identity);
        //Magicball mb = new Magicball(speed, myMaterial,myPrefab);
        ob.GetComponent<MagicBall>().Init();
        g_ListOfMagicBalls.Add(ob);
    }
    private void DestroyMagicBall(int indx)
    {
        print("Magic ball destroyed");
        GameObject.Destroy(g_ListOfMagicBalls[indx]);
        g_ListOfMagicBalls.RemoveAt(indx);
    }
}
