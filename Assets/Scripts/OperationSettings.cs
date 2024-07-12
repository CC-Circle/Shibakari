using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSettings : MonoBehaviour
{
    //マウス用の宣言
    public float moveSpeed = 0.001f;


    //M5Stack用の宣言
    public SerialReceive serialReceive; // Inspectorでセットするか、動的に取得
    private int leftRightCount = 0; // 左右の振りカウント
    private bool wasLeft = false; // 前回が左だったか
    public GameObject M5Stack;


    // Update is called once per frame
    void Update()
    {
        //Flagを入手するためのコード
        SerialHandler SerialHandler; //呼ぶスクリプトにあだなつける
        GameObject M5Stack = GameObject.Find("M5stack_Evnet"); //Playerっていうオブジェクトを探す
        SerialHandler = M5Stack.GetComponent<SerialHandler>(); //付いているスクリプトを取得

        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        if(SerialHandler.Settingsflag){//M5Stack操作

            if (serialReceive.Flag == 1)
            {
                currentPosition.x = -20;
                if (!wasLeft) // 前回が左でなければカウントを増加
                {
                    leftRightCount++;
                    wasLeft = true;
                }
                // 新しい位置を設定
                transform.position = currentPosition;
            }
            else if (serialReceive.Flag == 2)//マウス操作用
            {
                currentPosition.x = 20;
                if (wasLeft) // 前回が左だったらカウントを増加
                {
                    leftRightCount++;
                    wasLeft = false;
                }
                // 新しい位置を設定
                transform.position = currentPosition;
            }
            else
            {
                // x値だけをリセットした位置を取得
                currentPosition.x = 0;
                // 新しい位置を設定
                transform.position = currentPosition;
            }


        }else if(!SerialHandler.Settingsflag){
            // マウスのビューポート座標を取得 (0.0から1.0の範囲)
            Vector3 mouseViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            // ビューポートのx座標に基づいて判断
            float mouseX = mouseViewportPosition.x;

            if (mouseX < 0.4f)
            {
                currentPosition.x = -20;
                if (!wasLeft) // 前回が左でなければカウントを増加
                {
                    leftRightCount++;
                    wasLeft = true;
                }
            }
            else if (mouseX > 0.6f)
            {
                currentPosition.x = +20;
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
            }

            // 新しい位置を設定
            transform.position = currentPosition;
        }

        // 左右に一回ずつ振ったら前進
        if (leftRightCount >= 2)
        {
            currentPosition.z += 10; // 前進させる
            transform.position = currentPosition;
            leftRightCount = 0; // カウントをリセット
        }
    }
}
