//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Assets.Assets.Scripts.Player;

//public class Gun : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        RotateGun();
//        MoveGun();

//    }
//    private void RotateGun()
//    {
//        var mouse = Input.mousePosition;
//        mouse.z = 5.23f;
//        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
//        mouse.x -= screenPoint.x;
//        mouse.y -= screenPoint.y;
//        var angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
//        transform.rotation = Quaternion.Euler(0, 0, angle);

//    }
//    private void MoveGun()
//    {
//        Vector3 move = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, -3.08f);
//        transform.position = move;
//    }
//}
