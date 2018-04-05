using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField]
    Transform rayPosition;      //  Rayを飛ばす場所
    [SerializeField]
    float rayRange = 0.85f;     //  Rayを飛ばす距離
    [SerializeField]
    float deathRange;           //  死ぬ高さ

    float fallFloorPosition;    //  落ちた場所
    float fallDistance;         //  落ちてから床までの距離


    bool fallFlg;               //  落ちてるかどうか


    // Use this for initialization
    void Start()
    {
        fallDistance = 0f;
        fallFloorPosition = this.transform.position.y;
        fallFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
    }

    void Ray()
    {
        Debug.DrawLine(rayPosition.position, rayPosition.position + Vector3.down * rayRange, Color.red);

        //落ちている時
        if (fallFlg == true)
        {
            //  落下地点と現在地の距離を計算
            fallFloorPosition = Mathf.Max(fallFloorPosition, transform.position.y);
            Debug.Log(fallFloorPosition);

            //床にRayが当たったら
            if (Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Floor")))
            {
                //落下距離を計算
                fallDistance = fallFloorPosition - transform.position.y;
                //死ぬ高さなら殺す
                if (fallDistance >= deathRange)
                {
                    //ここに死亡処理を書く
                    Debug.Log("ここに死亡処理を書く");
                }
            }
        }
        else
        {
            //床にRayが当たってなければ落下地点を設定
            if (!Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Floor")))
            {
                //落下地点を設定
                fallFloorPosition = transform.position.y;
                fallDistance = 0;
                fallFlg = true;
            }
        }
    }
}
