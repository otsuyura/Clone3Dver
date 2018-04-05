using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Transform player;
    Rigidbody playerRb;

    public float speed = 0.1f;
    public float jump = 250;

    bool jumpFlg = true;
    // Use this for initialization
    void Start()
    {
        player = this.gameObject.GetComponent<Transform>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Debug.Log("jumpFlgは" + jumpFlg);
    }

    void Move()
    {

        //  左移動
        if (Input.GetKey(KeyCode.A))
        {
            player.Translate(Vector2.left * speed);
        }

        //  右移動
        if (Input.GetKey(KeyCode.D))
        {
            player.Translate(Vector2.right * speed);
        }

        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && jumpFlg == true)
        {
            playerRb.AddForce(Vector2.up * jump);
            jumpFlg = false;
        }
    }

    void OnTriggerEnter(Collider floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            jumpFlg = true;
        }
    }
}
