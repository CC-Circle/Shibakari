using UnityEngine;
using System.Collections.Generic;

public class CloudManager : MonoBehaviour
{
    public List<GameObject> cloudPrefabs; // 雲のPrefabをリストで指定する
    public int numberOfClouds = 10; // 生成する雲の数
    public Vector3 spawnAreaMin; // 雲の生成範囲の最小値
    public Vector3 spawnAreaMax; // 雲の生成範囲の最大値
    public float cloudSpeed = 1.0f; // 雲の移動速度

    private List<GameObject> clouds; // 生成された雲のリスト

    void Start()
    {
        // 雲のリストを初期化する
        clouds = new List<GameObject>();

        // 指定された数の雲を生成する
        for (int i = 0; i < numberOfClouds; i++)
        {
            // 生成範囲内でランダムな位置を決定する
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // ランダムに雲のPrefabを選択する
            GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Count)];
            // 選択されたPrefabを使って雲を生成する
            GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            // 生成された雲をリストに追加する
            clouds.Add(cloud);
        }
    }

    void Update()
    {
        // 各雲を更新する
        foreach (GameObject cloud in clouds)
        {
            if (cloud != null)
            {
                // 雲を右方向に移動させる
                cloud.transform.position += Vector3.right * cloudSpeed * Time.deltaTime;

                // 雲が生成範囲の右端を越えたら左端に戻す
                if (cloud.transform.position.x > spawnAreaMax.x)
                {
                    cloud.transform.position = new Vector3(spawnAreaMin.x, cloud.transform.position.y, cloud.transform.position.z);
                }
            }
        }
    }
}
