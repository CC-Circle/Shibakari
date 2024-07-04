using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BundleSize : MonoBehaviour
{
    public int Flag=0,COUNT=3;

    public GameObject grass; // プレハブの参照
    public string tagToAssign = "grass"; // タグの名前

    public TextMeshProUGUI Score;

    float score;

    public GameObject SceneManager; // シーンマネージャーのゲームオブジェクト
    private MySceneManager mySceneManager; // シーンマネージャースクリプトのインスタンス

    void Start()
    {
        mySceneManager = SceneManager.GetComponent<MySceneManager>(); // SceneManagerオブジェクトにアタッチされているMySceneManagerスクリプトを取得
        
    }

    void Update()
    {
        if(Flag==1){//フラグが立っていれば
            // プレハブからオブジェクトを生成
            GameObject obj = Instantiate(grass, new Vector3(0, 10, 0), Quaternion.identity);
            // オブジェクトにタグを付ける
            obj.tag = tagToAssign;
            Flag=0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (collision.gameObject.CompareTag("grass"))
        {
            if(COUNT<OperationSettings.Score/100-1){
                Destroy(collision.gameObject);
                COUNT++;//何回か数える
                Flag=1;//フラグを立てる
                transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); // x、y、z方向それぞれに0.4ずつサイズを増加させる
                score+=100;
                //単位をつけて代入
                if(score<1000){
                    Score.text = Mathf.FloorToInt(score).ToString("F0") + "g";
                }else{
                    Score.text = (score / 1000f).ToString("F1") + "kg";
                }
            }else{
                Destroy(collision.gameObject);
                score+=100;
                mySceneManager.flag = true; // MySceneManagerスクリプトを有効化
            }
        }
    }
}
