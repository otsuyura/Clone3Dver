using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swtich_j : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            swtich.S_push++;
            Debug.Log("乗った");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            swtich.S_push--;
            Debug.Log("離れた");
        }

    }
}
