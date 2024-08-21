using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProを使用するための名前空間
using UnityEngine.SceneManagement; // シーン管理の名前空間

public class TimeCounter : MonoBehaviour
{
    public float CountTime = 40; // カウントダウンの秒数を設定
    //[SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;

    public GameObject SceneManager; // シーンマネージャーのゲームオブジェクト
    private MySceneManager mySceneManager; // シーンマネージャースクリプトのインスタンス

    // Startは最初のフレームの前に一度だけ呼び出される
    void Start()
    {
        mySceneManager = SceneManager.GetComponent<MySceneManager>(); // SceneManagerオブジェクトにアタッチされているMySceneManagerスクリプトを取得
    }

    // Updateは毎フレーム呼び出される
    void Update()
    {
        // 時間を減らす
        CountTime -= Time.deltaTime;
        // 小数点以下を非表示にして時間をテキストに表示
        uiText.text = Mathf.FloorToInt(CountTime).ToString("F0");
        // FillのFillAmountを時間に応じて変化
        //uiFill.fillAmount = Mathf.InverseLerp(0, 40, CountTime);

        if (CountTime <= 0) // カウントが0になったら
        {
            mySceneManager.flag = true; // MySceneManagerスクリプトを有効化
        }
    }
}
