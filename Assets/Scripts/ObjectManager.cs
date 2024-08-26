using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    //共通宣言
    private string NowScene; // シーンを格納する変数

    //ゲームシーンの宣言
    public GameObject Grass; // プレハブの参照
    public GameObject alternatePrefab; // 別のプレハブの参照
    private int numObjects = 5; // オブジェクトの数
    private float zDistance = 35f; // Z軸の距離
    private int generationCounter = 0;
    private int alternatePrefabCooldown = 0; // alternatePrefabカウンター

    //リザルトの宣言
    public GameObject grass; // プレハブの参照
    public string tagToAssign = "grass"; // タグの名前
    // 位置を取得する対象のオブジェクト
    public GameObject grassObject;
    int COUNT=0;
    private bool Flag = false;

    void Start()
    {
        // 初期オブジェクトを生成
        for (int i = 0; i < numObjects; i++)
        {
            Instantiate(Grass, new Vector3(0, 13.5f, (i * zDistance) + 40), Quaternion.Euler(-90, 0, 0));
        }
    }

    void Update()
    {
        NowScene = SceneManager.GetActiveScene().name; // 現在のシーン名を変数に代入

        if(NowScene == "main")
        {
            // タグ付きオブジェクトを取得
            GameObject[] grassObjects = GameObject.FindGameObjectsWithTag("grass");
            GameObject[] moleObjects = GameObject.FindGameObjectsWithTag("Mole");
            List<GameObject> validObjects = new List<GameObject>(grassObjects);
            validObjects.AddRange(moleObjects);

            // オブジェクトが2個以下になった場合
            if (validObjects.Count <= 3)
            {
                // 現在の最大Z位置を取得
                float maxZ = 0;
                foreach (var obj in validObjects)
                {
                    if (obj.transform.position.z > maxZ)
                    {
                        maxZ = obj.transform.position.z;
                    }
                }

                // 新しいオブジェクトのスタート位置
                Vector3 startPosition = new Vector3(0, 13.5f, maxZ + zDistance);

                // ランダムなインデックスを生成
                int randomIndex = Random.Range(0, 10);

                // 新しいオブジェクトを生成
                for (int i = 0; i < numObjects; i++)
                {
                    // alternatePrefabが生成された後20個先までは生成しない
                    if (alternatePrefabCooldown == 0 && generationCounter % 10 == randomIndex)
                    {
                        zDistance-=5;
                        Vector3 position = startPosition + new Vector3(0, 0, i * zDistance);
                        Instantiate(alternatePrefab, position, Quaternion.identity);
                        alternatePrefabCooldown = 10; // 20個先まではalternatePrefabを生成しない
                    }
                    else
                    {
                        Vector3 position = startPosition + new Vector3(0, 0, i * zDistance);
                        Instantiate(Grass, position, Quaternion.Euler(-90, 0, 0));
                        if (alternatePrefabCooldown > 0)
                        {
                            alternatePrefabCooldown--;
                        }
                        if(zDistance<30){
                            zDistance = 35f;
                        }
                    }
                    generationCounter++;
                }
            }
        }
        else if(NowScene == "end")
        {
            Vector3 targetPosition = grassObject.transform.position;
            // 現在のオブジェクトのY軸が2.5以下かどうかをチェック
            if (targetPosition.y <= 8)
            {
                //Debug.Log(WriteScore.score);

                if(Flag==false){
                    COUNT=WriteScore.score/100-1;
                    Flag=true;
                }
                if(COUNT!=0){
                    // プレハブからオブジェクトを生成
                    GameObject obj = Instantiate(grass, new Vector3(0, 10, 0), Quaternion.identity);
                    grassObject = obj;
                    COUNT--;
                }
            }
        } 
    }
}
