using UnityEngine;
using System.Collections;

public class AutoDestroyAndSpawn : MonoBehaviour
{
    public float lifetime = 5f; // オブジェクトが破壊されるまでの時間（秒）
    public GameObject spawnPrefab; // 破壊後に生成されるオブジェクトのプレハブ

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
        Destroy(gameObject);
        Debug.Log("Destroyed " + gameObject.name + " after " + lifetime + " seconds");

        // 新しいオブジェクトを初期位置に生成
        initialPosition.y = 13.5f; // オブジェクトが地面に埋まらないように少し浮かせる    
        Instantiate(spawnPrefab, initialPosition, Quaternion.Euler(270, 0, 0));
        Debug.Log("Spawned new object at " + initialPosition);
    }
}
