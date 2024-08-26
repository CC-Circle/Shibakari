using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WriteScore : MonoBehaviour
{
    //共通宣言
    private string nowScene; // シーンを格納する変数
    public CollisionDetection collisionDetection; // Inspectorでセットするか、動的に取得
    public static int score,Score; // スコアの変数
    public TextMeshProUGUI scoreText;//スコアを入れるテキスト

    //リザルト用
    public  bool flag=false;
    public static int ScoreFlag=0;

    void Start()
    {
        nowScene = SceneManager.GetActiveScene().name; // 現在のシーン名を変数に代入
        // コリジョンデテクションスクリプトを動的に取得
        GameObject cylinder = GameObject.Find("円柱"); // 円柱オブジェクトを探す
        collisionDetection = cylinder.GetComponent<CollisionDetection>(); // 付いているスクリプトを取得
    }

    void Update()
    {
        if (nowScene == "main")
        {
            if (collisionDetection != null && collisionDetection.ScoreFlag == 1)
            {
                score += 100;
                Score = score;
                collisionDetection.ScoreFlag = 0; // フラグをリセット（必要に応じて）
            }
             if (collisionDetection != null && collisionDetection.ScoreFlag == 2)
            {
                score -= 500;
                Score = score;
                collisionDetection.ScoreFlag = 0; // フラグをリセット（必要に応じて）
            }
        }
        else if (nowScene == "end")
        {
            if(flag == false){
                flag=true;
                Score = 0;
            }
            // リザルトの処理
            if (ScoreFlag == 1)
            {
                Score += 100;
                ScoreFlag = 0;
            }
        }


        // スコアの表示更新
        if (scoreText != null)
        {
            if (Score < 1000)
            {
                scoreText.text = Mathf.FloorToInt(Score).ToString("F0") + "g";
            }
            else
            {
                scoreText.text = (Score / 1000f).ToString("F1") + "kg";
            }
        }
    }
}

