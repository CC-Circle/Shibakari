using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProを使用するための名前空間
using UnityEngine.SceneManagement; // シーン管理の名前空間

public class TimeCounter : MonoBehaviour
{
    public float countdownSec = 40; // カウントダウンの秒数を設定
    public TMP_Text timeText; // 時間表示用のTextMeshProのテキスト
    public GameObject SceneManager; // シーンマネージャーのゲームオブジェクト
    private MySceneManager mySceneManager; // シーンマネージャースクリプトのインスタンス

    // Startは最初のフレームの前に一度だけ呼び出される
    void Start()
    {
        timeText = GetComponent<TMP_Text>(); // このオブジェクトにアタッチされているTMP_Textコンポーネントを取得
        mySceneManager = SceneManager.GetComponent<MySceneManager>(); // SceneManagerオブジェクトにアタッチされているMySceneManagerスクリプトを取得
    }

    // Updateは毎フレーム呼び出される
    void Update()
    {
        // 時間を減らす
        countdownSec -= Time.deltaTime;
        // 小数点以下を非表示にして時間をテキストに表示
        timeText.text = "TIME : " + Mathf.FloorToInt(countdownSec).ToString("F0");

        if (countdownSec <= 0) // カウントが0になったら
        {
            mySceneManager.flag = true; // MySceneManagerスクリプトを有効化
        }
    }
}
