using UnityEngine;
using System.Collections.Generic;

public class CloudManager : MonoBehaviour
{
    public List<GameObject> cloudPrefabs; // 雲のPrefabをリストで指定する
    public int numberOfClouds = 10; // 生成する雲の数
    // -200, 50, 100
    // 200, 100, 200
    public Vector3 spawnAreaMin; // 雲の生成範囲の最小値
    public Vector3 spawnAreaMax; // 雲の生成範囲の最大値
    public float cloudSpeed = 1.0f; // 雲の移動速度

    private List<GameObject> clouds;

    void Start()
    {
        clouds = new List<GameObject>();

        for (int i = 0; i < numberOfClouds; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // ランダムに雲のPrefabを選択する
            GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Count)];
            GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            clouds.Add(cloud);
        }
    }

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            if (cloud != null)
            {
                cloud.transform.position += Vector3.right * cloudSpeed * Time.deltaTime;

                if (cloud.transform.position.x > spawnAreaMax.x)
                {
                    cloud.transform.position = new Vector3(spawnAreaMin.x, cloud.transform.position.y, cloud.transform.position.z);
                }
            }
        }
    }
}
