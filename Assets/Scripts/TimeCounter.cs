using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProを使用するための名前空間
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using UnityEditor.UIElements;
using System.Media; // シーン管理の名前空間

public class TimeCounter : MonoBehaviour
{
    public float CountTime = 40; // カウントダウンの秒数を設定
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    public GameObject SceneManager; // シーンマネージャーのゲームオブジェクト
    private MySceneManager mySceneManager; // シーンマネージャースクリプトのインスタンス
    public GameObject[] UiElements; // UIのゲームオブジェクト
    private float PauseTime = 0; // 一時停止時間を計測するための変数
    [SerializeField] public GameObject FinishText; // ゲーム終了時に表示するテキスト
    [SerializeField] public AudioSource FinishSound; // ゲーム終了時に再生するサウンド

    // Startは最初のフレームの前に一度だけ呼び出される
    void Start()
    {
        mySceneManager = SceneManager.GetComponent<MySceneManager>(); // SceneManagerオブジェクトにアタッチされているMySceneManagerスクリプトを取得
        UiElements = GameObject.FindGameObjectsWithTag("UI");
        FinishText.SetActive(false); // ゲーム終了時に表示するテキストを非表示
    }

    // Updateは毎フレーム呼び出される
    void Update()
    {
        if (ReadyToStart.flag)
        {
            // 時間を減らす
            CountTime -= Time.deltaTime;
            // 小数点以下を非表示にして時間をテキストに表示
            uiText.text = Mathf.FloorToInt(CountTime).ToString("F0");
            // FillのFillAmountを時間に応じて変化
            uiFill.fillAmount = Mathf.InverseLerp(0, 40, CountTime);
        }

        //　処理1と処理2の順番を変更しないでください
        //　処理1
        // CountTimeのみでも可能だが，可読性向上のために，PauseTimeを使って条件分岐
        if (PauseTime >= 3)
        {
            mySceneManager.flag = true; // MySceneManagerスクリプトを有効化
        }

        // 処理2
        if (CountTime <= 0) // カウントが0になったら
        {
            PauseTime += Time.deltaTime; // 一時停止時間の計測開始

            foreach (GameObject UiElement in UiElements)
            {
                CanvasGroup canvasGroup = UiElement.GetComponent<CanvasGroup>();
                if (canvasGroup == null)
                {
                    // CanvasGroupがアタッチされていない場合、追加する
                    canvasGroup = UiElement.AddComponent<CanvasGroup>();
                }
                // UIの透明度を0にして、インタラクティブとレイキャストを無効化
                // setActive(false)で実装すると，うまくいかなかったので，CanvasGroupを使って透明度を変更する方法を採用
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
            FinishText.SetActive(true); // ゲーム終了時に表示するテキストを表示
            FinishSound = GetComponent<AudioSource>(); // ゲーム終了時に再生するサウンドを取得
            FinishSound.Play(); // ゲーム終了時にサウンドを再生


        }
    }
}
