using UnityEngine;

public class Move : MonoBehaviour
{
    public float sensitivity = 1.0f; // マウス感度
    public Vector3 _velocity;
    public GameObject obj;

    private float lastMouseX; // 前フレームのマウスのX座標

    // イベントの実行メソッド
    void OnMouseMoved(float deltaX)
    {
        // ここにイベントの実行内容を書く
        //Debug.Log("マウスが移動しました。移動量: " + deltaX);
        obj.transform.position += _velocity;
    }

    void Update()
    {
        // マウスのX座標の変化量を計算
        float mouseX = Input.GetAxis("Mouse X");
        float deltaX = mouseX - lastMouseX;
        lastMouseX = mouseX;

        // マウスの移動量に応じてイベントを実行
        if (Mathf.Abs(deltaX) > 1f)
        {
            OnMouseMoved(deltaX * sensitivity);
        }
    }
}
