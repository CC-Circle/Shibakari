using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOn : MonoBehaviour
{
    // 触れたときにトリガーをオンにするタグ名
    public string targetTag = "refe";

    // トリガーがオンになったときに行うアクション
    public UnityEngine.Events.UnityEvent onTrigger;

    // コライダーがトリガーを持っている場合に呼ばれるメソッド
    private void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトのタグをチェック
        if (other.CompareTag(targetTag))
        {
            // トリガーをオンにするアクションを実行
            onTrigger.Invoke();
            Debug.Log("２：トリガーオンになった。");
        }
    }

    // コライダーがトリガーを持っていない場合に呼ばれるメソッド
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグをチェック
        if (collision.gameObject.CompareTag(targetTag))
        {
            // トリガーをオンにするアクションを実行
            onTrigger.Invoke();
             Debug.Log("１：トリガーオンになった。");
        }
    }
}
