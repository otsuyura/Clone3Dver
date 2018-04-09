using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCorsol : MonoBehaviour
{
    //public Texture2D cursolTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    //Vector3 screenPosition;

    [SerializeField]
    private GameObject cursol = null;
    //public GameObject cursol;
    //public Camera mainCamera;
    public GameObject player;

    Vector3 cursolWorldPosition;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Corsol();
        CloneInstance();
    }

    void Corsol()
    {
        //------
        //

        Vector3 cursolScreenPosition = Input.mousePosition;

        // 画面からカーソルのオブジェクトが出ないようにする
        cursolScreenPosition.x = Mathf.Clamp(cursolScreenPosition.x, 0.0f, Screen.width);
        cursolScreenPosition.y = Mathf.Clamp(cursolScreenPosition.y, 0.0f, Screen.height);
        cursolScreenPosition.z = 10.5f;

        // プレイヤーからカーソルに向かってRayを飛ばす
        Camera gameCamera = Camera.main;    // カメラに MainCameraタグが付いていないと参照エラーが起こる
        //Ray cursolPointRay = gameCamera.ScreenPointToRay(cursolScreenPosition);
        Ray cursolPointRay = new Ray(this.transform.position, cursol.transform.position);      // Ray(原点(Vector3), 方角(Vector3));

        Debug.DrawRay(cursolPointRay.origin, cursolPointRay.direction * 1000.0f);

        // カーソルにオブジェクトを追従させる
        cursolWorldPosition = gameCamera.ScreenToWorldPoint(cursolScreenPosition);
        cursol.transform.position = cursolWorldPosition;

        //
        //------
    }

    void CloneInstance()
    {
        if(Input.GetMouseButtonDown(0))     // 左クリック
        {
            Instantiate(player, cursolWorldPosition, Quaternion.identity);
        }
    }

    void OnMouseEnter()     // マウスカーソルがこのオブジェクトに乗ったら
    {
        //Cursor.SetCursor(cursolTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        //Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}
