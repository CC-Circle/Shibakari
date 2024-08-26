using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObjectManager : MonoBehaviour
{
    public string targetTag = "grass"; // 触れたオブジェクトに付けたいタグ
    private int hitCount = 0; // 触れた回数

    // オブジェクトが触れたときに呼び出されるメソッド
    void OnTriggerEnter(Collider other)
    {
        // 触れたオブジェクトが指定したタグを持っているか確認
        if (other.CompareTag(targetTag))
        {
            hitCount++; // カウントを増加

            // 5回触れたごとにオブジェクトのY軸スケールを+0.1増やす
            if (hitCount % 5 == 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.y += 0.1f; // Y軸のスケールを増やす
                transform.localScale = newScale;
            }

            // 触れたオブジェクトを消去する
            Destroy(other.gameObject);
        }
    }
}
