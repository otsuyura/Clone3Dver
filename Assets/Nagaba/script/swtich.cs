using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swtich : MonoBehaviour {

    public int number;//スイッチの押さなくてはいけない数
    static public int S_push;//スイッチが押されているかどうか
    bool allpush;//全てのスイッチが押されているかどうか
    float limitValue = 0f;//ドアが開いたか調べる
    public float speed;//ドアの動くスピード

    public GameObject door;

    Vector3 pos;//扉の座標

	// Use this for initialization
	void Start () {
        pos = door.transform.position;//テスト
    }

    // Update is called once per frame
    void Update()
    {
        if (number <= S_push)
        {
            hiraku();
        }
        else if (number >= S_push)
        {
            toziru();
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            S_push++;
            Debug.Log("乗った");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            S_push--;
            Debug.Log("離れた");
        }

    }
        private void hiraku()
    {

        if (limitValue < 90 && limitValue > -90)//ドアが開いたか調べる
        {
            door.gameObject.transform.Rotate(speed, 0.0f, 0.0f);//ドアが開く処理
            limitValue += speed;//ドアの限界値への加算
        }
    }
    private void toziru()
    {
        if (limitValue < 91 && limitValue > 0)//ドアが開いたか調べる
        {
            door.gameObject.transform.Rotate(-speed, 0.0f, 0.0f);//ドアが開く処理
            limitValue -= speed;//ドアの限界値への加算
        }
    }

}
