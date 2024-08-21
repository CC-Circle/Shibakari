using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSettings : MonoBehaviour
{
    public float moveSpeed = 70f;
    public GameObject mainCamera;
    public SerialReceive serialReceive;
    private int leftRightCount = 0;
    private bool wasLeft = false;
    public GameObject M5Stack;
    private float currentRotationY = 0f;
    public float distanceFromCamera = 5f; // カメラからの距離
    private Vector3 lastMousePosition;

    void Start()
    {
        // 初期化時にマウスの位置を保存
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (ReadyToStart.flag)
        {
            //Flagを入手するためのコード
            SerialHandler SerialHandler; //呼ぶスクリプトにあだなつける
            GameObject M5Stack = GameObject.Find("M5stack_Evnet"); //Playerっていうオブジェクトを探す
            SerialHandler = M5Stack.GetComponent<SerialHandler>(); //付いているスクリプトを取得

            float rotationSpeed = 0.1f; // 回転速度
            float moveAmount = 5f * Time.deltaTime;

            // 現在の位置を取得
            Vector3 currentPosition = transform.position;


            if (SerialHandler.Settingsflag)
            { //M5Stack操作

                if (serialReceive.Flag == 1)
                {
                    // Y軸-30度回転
                    transform.rotation = Quaternion.Euler(0, -50, 0);
                    if (!wasLeft) // 前回が左でなければカウントを増加
                    {
                        leftRightCount++;
                        wasLeft = true;
                    }
                }
                else if (serialReceive.Flag == 2) // マウス操作用
                {
                    // Y軸30度回転
                    transform.rotation = Quaternion.Euler(0, 50, 0);
                    if (wasLeft) // 前回が左だったらカウントを増加
                    {
                        leftRightCount++;
                        wasLeft = false;
                    }
                }
                else
                {
                    // x値だけをリセットした位置を取得
                    currentPosition.x = 0;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else if (!SerialHandler.Settingsflag)
            {
                // 十字キーでの進行方向変更（回転）
                float h = Input.GetAxis("Horizontal"); // 左右キーの取得
                transform.Rotate(0, rotationSpeed * h * 25, 0);

                // マウスのX方向の移動距離を計算
                Vector3 currentMousePosition = Input.mousePosition;
                float mouseDeltaX = currentMousePosition.x - lastMousePosition.x;

                // マウスの移動に応じてプレイヤーを回転
                transform.Rotate(0, mouseDeltaX * rotationSpeed, 0);

                // マウスの移動距離に応じて前進
                if (Mathf.Abs(mouseDeltaX) > 0)
                {
                    transform.position += transform.forward * Mathf.Abs(mouseDeltaX) * moveSpeed * 10;
                    // 高さは固定
                    transform.position = new Vector3(transform.position.x, 30, transform.position.z);
                }

                // 現在のマウス位置を次のフレーム用に保存
                lastMousePosition = currentMousePosition;
            }
        }
    }
}