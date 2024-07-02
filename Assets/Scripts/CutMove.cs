using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutMove : MonoBehaviour
{
    public SerialReceive serialReceive; // Inspectorでセットするか、動的に取得
    private int leftRightCount = 0; // 左右の振りカウント
    private bool wasLeft = false; // 前回が左だったか

    private GameObject objectToDestroy = null;//草に触れたかどうかの判定フラグ

    public static int Score;//スコアの変数
    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (collision.gameObject.CompareTag("grass"))
        {
            // オブジェクトを消すフラグを立てる
            objectToDestroy = collision.gameObject;
        }
    }
    void Update()
    {
        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        if (serialReceive.Flag == 1)
        {
            currentPosition.x = -20;
            if (!wasLeft) // 前回が左でなければカウントを増加
            {
                leftRightCount++;
                wasLeft = true;
            }
        }
        else if (serialReceive.Flag == 2)
        {
            currentPosition.x = 20;
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

        // 左右に一回ずつ振ったら前進
        if (leftRightCount >= 2)
        {
            // フラグが立っている場合、オブジェクトを消す
            if (objectToDestroy != null)
            {
                //オブジェクトを消す
                Destroy(objectToDestroy);
                objectToDestroy = null;
                //スコアを増やす
                Score+=100;
            }
            currentPosition.z += 10; // 前進させる
            transform.position = currentPosition;
            leftRightCount = 0; // カウントをリセット
        }
    }
}
