using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSettings : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    public GameObject mainCamera;
    public SerialReceive serialReceive;
    private int leftRightCount = 0;
    private bool wasLeft = false;
    public GameObject M5Stack;
    private float currentRotationY = 0f;
    public float distanceFromCamera = 5f; // カメラからの距離

    void Update()
    {
        if (ReadyToStart.flag)
        {
            //Flagを入手するためのコード
            SerialHandler SerialHandler; //呼ぶスクリプトにあだなつける
            GameObject M5Stack = GameObject.Find("M5stack_Evnet"); //Playerっていうオブジェクトを探す
            SerialHandler = M5Stack.GetComponent<SerialHandler>(); //付いているスクリプトを取得

            float rotationSpeed = 90f; // 回転速度
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
                // マウスのビューポート座標を取得 (0.0から1.0の範囲)
                Vector3 mouseViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                // ビューポートのx座標に基づいて判断
                float mouseX = mouseViewportPosition.x;

                if (mouseX < 0.4f)
                {
                    if (!wasLeft) // 前回が左でなければカウントを増加
                    {
                        // Y軸-30度回転
                        transform.rotation = Quaternion.Euler(0, -50, 0);
                        leftRightCount++;
                        wasLeft = true;
                    }
                }
                else if (mouseX > 0.6f)
                {
                    if (wasLeft) // 前回が左だったらカウントを増加
                    {
                        // Y軸30度回転
                        transform.rotation = Quaternion.Euler(0, 50, 0);
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

            // 前後移動
            if (leftRightCount >= 2)
            {
                currentPosition.z += 10;
                transform.position = currentPosition;
                leftRightCount = 0;
            }

            // 左右移動と回転
            if (Input.GetKey(KeyCode.A))
            {
                // 左に移動
                currentRotationY += rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
                // カメラも回転
                mainCamera.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
                mainCamera.transform.Translate(Vector3.left * moveAmount);
            }

            if (Input.GetKey(KeyCode.D))
            {
                // 右に移動
                currentRotationY -= rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
                // カメラも回転
                mainCamera.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
                mainCamera.transform.Translate(Vector3.right * moveAmount);
            }
        }
    }
}