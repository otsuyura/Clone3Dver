//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerRay : MonoBehaviour
//{
//    Vector3 screenPosition;
//    public Transform sphere;

//    // Use this for initialization
//    void Start ()
//    {
//        sphere = gameObject.GetComponent<Transform>();
//	}
	
//	// Update is called once per frame
//	void Update ()
//    {
//        Corsol();
//	}

//    void Corsol()
//    {
//        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
//        //Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

//        Vector3 corsolPosition2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
//        Ray ray = new Ray(transform.position, sphere.transform.position);      // Ray(原点(Vector3), 方角(Vector3));
//        //Vector3 corsolPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

//        Debug.DrawRay(ray.origin, corsolPosition2, Color.blue, 3, false);
//        Debug.Log(corsolPosition2);
//    }
//}
