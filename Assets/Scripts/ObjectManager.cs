using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject prefab; // プレハブの参照
    private int numObjects = 5; // オブジェクトの数
    private float zDistance = 20f; // Z軸の距離

    int P=5;

    void Start()
    {
        // 初期オブジェクトを生成
        for (int i = 0; i < numObjects; i++)
        {
            Instantiate(prefab, new Vector3(0, 14, i * zDistance + 60), Quaternion.identity);
        }
    }

    void Update()
    {
        // タグ付きオブジェクトを取得
        GameObject[] objects = GameObject.FindGameObjectsWithTag("grass");
        List<GameObject> validObjects = new List<GameObject>();

        // 有効なオブジェクトをフィルタリング
        foreach (var obj in objects)
        {
            if (obj != null)
            {
                validObjects.Add(obj);
            }
        }

        // オブジェクトが3個未満になった場合
        if (validObjects.Count < 3)
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
            Vector3 startPosition = new Vector3(0, 14, maxZ + zDistance);

            // 新しいオブジェクトを生成
            for (int i = 0; i < numObjects; i++)
            {
                Instantiate(prefab, startPosition + new Vector3(0, 0, i * zDistance), Quaternion.identity);
                P++;
            }
        }
    }
}
