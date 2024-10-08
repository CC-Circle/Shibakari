using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    // 衝突判定スクリプト

    private string NowScene; // 現在のシーン名を格納する変数

    private GameObject Grassbject = null; // 草に触れたかどうかの判定フラグ

    private GameObject MoleObject = null; // モグラに触れたかどうかの判定フラグ

    public int ScoreFlag = 0; // スコアを加算減算するフラグ

    AudioSource audioSource; // オーディオを格納する変数

    public AudioSource moleCollisionSound;

    public GameObject newPrefab; // 新しいオブジェクトのプレハブ

    public int isMoguraDestory = 0; // モグラが破壊されたかどうかの判定フラグ

    // 衝突した時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (collision.gameObject.CompareTag("grass"))
        {
            // オブジェクトを消すフラグを立てる
            Grassbject = collision.gameObject;
        }

        // 衝突したオブジェクトが "Mole" タグを持っているか確認
        if (collision.gameObject.CompareTag("Mole"))
        {
            // オブジェクトを消すフラグを立てる
            MoleObject = collision.gameObject;
        }
    }

    // 初期化処理
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 毎フレーム呼ばれる関数
    void Update()
    {
        //Flagを入手するためのコード
        SerialReceive SerialReceive; //呼ぶスクリプトにあだなつける
        GameObject M5Stack = GameObject.Find("M5stack_Evnet"); //Playerっていうオブジェクトを探す
        SerialReceive = M5Stack.GetComponent<SerialReceive>(); //付いているスクリプトを取得

        //上方向を判定した時に，デバッグログに表示
        if (SerialReceive.Flag == 3)
        {
            Debug.Log("up");
        }

        NowScene = SceneManager.GetActiveScene().name; // 現在のシーン名を変数に代入

        // 現在のシーンが "start" の場合
        if (NowScene == "start")
        {
            // タイトルの変更（実際の処理は未実装）
        }
        // 現在のシーンが "main" の場合
        else if (NowScene == "main")
        {
            if (ReadyToStart.flag)
            {
                // 草を消すフラグが立っている場合、オブジェクトを消す
                if (Grassbject != null)
                {
                    Vector3 position = Grassbject.transform.position; // オブジェクトの位置を取得
                    position.y = 0; // Y軸の位置を0に固定
                    Destroy(Grassbject); // 草を消す
                    audioSource.PlayOneShot(audioSource.clip); // オーディオを再生
                    ScoreFlag = 1; // スコアフラグを立てる

                    // 新しいオブジェクトを元の位置に生成
                    Instantiate(newPrefab, position, Quaternion.Euler(90, 0, 0));
                    position.x -= 5; // Y軸の位置を0に固定
                    position.z -= 5; // Y軸の位置を0に固定
                    Instantiate(newPrefab, position, Quaternion.Euler(90, 0, 0));
                    // 生成したオブジェクトにタグを追加
                    newPrefab.tag = "AfterGrass";
                    // 生成したオブジェクトにAutoDestroyAndSpawnスクリプトを追加
                    if (newPrefab.GetComponent<AutoDestroyAndSpawn>() == null)
                    {
                        AutoDestroyAndSpawn autoDestroy = newPrefab.AddComponent<AutoDestroyAndSpawn>();
                        autoDestroy.lifetime = 5f; // 5秒後に破壊されるように設定
                    }
                }

                // モグラを消すフラグが立っている場合、オブジェクトを消す
                if (MoleObject != null)
                {
                    Destroy(MoleObject); // モグラを消す
                    audioSource.PlayOneShot(moleCollisionSound.clip); // オーディオを再生
                    ScoreFlag = 2; // スコアフラグを立てる
                    isMoguraDestory = 1;
                }
            }
        }
        // 現在のシーンが "end" の場合
        else if (NowScene == "end")
        {
            
        }
    }
}