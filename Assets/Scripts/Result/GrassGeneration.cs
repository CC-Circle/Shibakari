using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGeneration : MonoBehaviour
{
    public GameObject grassPrefab; // grassタグのついたプレハブをアサイン
    public Transform targetObject; // 対象のオブジェクトをアサイン
    public Vector3 spawnPosition = new Vector3(0, 15, 0); // 生成位置

    private int COUNT=0; // 残りの生成回数

    void Start()
    {
        COUNT = WriteScore.score / 100; // 生成回数を初期化
    }

    void Update()
    {
        if(COUNT!=0 && targetObject.position.y<13f){

            // プレハブを指定の位置に生成
            GameObject newObject = Instantiate(grassPrefab, spawnPosition, Quaternion.identity);
            newObject.tag = "grass"; // タグを設定
            // 新しく生成されたオブジェクトを次のターゲットに設定
            targetObject = newObject.transform;
            COUNT--;
            WriteScore.ScoreFlag = 1;
        }
    }
}
