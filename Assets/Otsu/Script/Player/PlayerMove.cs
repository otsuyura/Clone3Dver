using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Transform player;
    Rigidbody playerRb;
    float jumpFloorPosition;    //  ジャンプした座標
    float playerPosition;       //  プレイヤーのリアルタイムの座標

    public float speed = 0.1f;  //  プレイヤーの移動速度
    public float jump = 250;    //  プレイヤーのジャンプパワー

    bool jumpFlg;
    bool aKeyPushFlg;           //  Aキーが押されてるかどうか
    // Use this for initialization
    void Start()
    {
        player = this.gameObject.GetComponent<Transform>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();

        jumpFlg = false;
        aKeyPushFlg = true;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //ジャンプしてないとき
        if (jumpFlg == false)
        {
            //  左移動
            if (Input.GetKey(KeyCode.A))
            {
                player.Translate(Vector2.left * speed);
                Debug.Log("左移動中");
            }
            //  右移動
            else if (Input.GetKey(KeyCode.D))
            {
                player.Translate(Vector2.right * speed);
                Debug.Log("右移動中");
            }
        }
        //ジャンプしてるとき
        else
        {
            //左にジャンプしているとき
            if (aKeyPushFlg == true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    playerRb.AddForce(Vector2.right * (jump - 240));
                }
            }
            //右にジャンプしているとき
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    playerRb.AddForce(Vector2.left * (jump - 240));
                }
            }
        }

    }

    void Jump()
    {
        Debug.Log(jumpFlg + "ジャンプフラグ");
        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && jumpFlg == false)
        {
            //jumpFloorPosition = this.transform.position.y;

            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Aキー入力");
                playerRb.AddForce(Vector2.up * jump);
                playerRb.AddForce(Vector2.left * (jump - 50));
                aKeyPushFlg = true;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerRb.AddForce(Vector2.up * jump);
                playerRb.AddForce(Vector2.right * (jump - 50));
                aKeyPushFlg = false;
            }
            else
            {
                playerRb.AddForce(Vector2.up * jump);
            }

            //playerPosition = this.transform.position.y;

            jumpFlg = true;


        }

    }

    void OnTriggerEnter(Collider floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            playerRb.velocity = new Vector3(0, 0, 0);
            jumpFlg = false;
        }
    }

}
