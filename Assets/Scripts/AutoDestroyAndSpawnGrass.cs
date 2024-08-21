using UnityEngine;
using System.Collections;

public class AutoDestroyAndSpawn : MonoBehaviour
{
    public float lifetime = 5f; // オブジェクトが破壊されるまでの時間（秒）

    [Header("草")]
    public GameObject spawnPrefab_grass; // 破壊後に生成されるオブジェクトのプレハブ

    [Header("もぐら")]
    public GameObject spawnPrefab_mogura; // 1％の確率で生成される異なるオブジェクトのプレハブ

    private Vector3 initialPosition;

    void Start()
    {
        // コルーチンを開始して時間経過後にオブジェクトを破壊
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        // 初期位置を記録
        initialPosition = transform.position;

        // 指定された時間だけ待つ
        yield return new WaitForSeconds(lifetime);

        // オブジェクトを破壊
        //Destroy(gameObject);
        Debug.Log("Destroyed " + gameObject.name + " after " + lifetime + " seconds");

        // 1％の確率で異なるオブジェクトを生成
        GameObject objToSpawn;
        if (Random.value <= 0.01f) // 1％の確率
        {
            objToSpawn = spawnPrefab_mogura;
            // オブジェクトが地面に埋まらないように少し浮かせる    
            initialPosition.y = 13.5f;

            // 新しいオブジェクトを初期位置に生成
            Instantiate(objToSpawn, initialPosition, Quaternion.Euler(0, -2, 0));
        }
        else
        {
            objToSpawn = spawnPrefab_grass;
            // オブジェクトが地面に埋まらないように少し浮かせる    
            initialPosition.y = 13.5f;

            // 新しいオブジェクトを初期位置に生成
            Instantiate(objToSpawn, initialPosition, Quaternion.Euler(270, 0, 0));
        }
    }
}
