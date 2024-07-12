using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    // 追従するターゲット
    public Transform target;
    
    // 保持したいz軸方向の距離
    public float distanceZ = 20.0f;

    // 保持したい高さ
    public float height = 0.0f;

    void Update()
    {
        if (target != null)
        {
            // 新しい位置を計算
            Vector3 newPosition = new Vector3(
                0,  // x軸はゼロで固定
                target.position.y + height,  // 高さを保持
                target.position.z - distanceZ  // ターゲットからの距離を保持
            );

            // オブジェクトを新しい位置に移動
            transform.position = newPosition;
        }
    }
}
