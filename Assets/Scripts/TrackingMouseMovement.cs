using UnityEngine;

public class TrackingMouseMovement : MonoBehaviour
{
    // オブジェクトの移動速度
    public float moveSpeed = 0.001f;
    
    private void Update()
    {
        // マウスのX座標を取得(ビューポート画面の中央を原点とする)
        float mouseX = Input.mousePosition.x - Screen.width / 2f;

        // マウスのX座標をビューポート座標に変換
        Vector3 viewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Debug.Log(viewportPosition);

        // ビューポート内にマウスの座標があるかをチェック
        if (viewportPosition.x >= 0.2 && viewportPosition.x <= 0.8)
        {
            // 新しい位置を計算し、y座標とz座標は現在の位置を使う
            // yとzについてはtranform.position.yとtransform.position.zを使うより
            // 直接値を指定した方が値固定がうまくいく（それでも完璧ではない）
            Vector3 newPosition = new Vector3(mouseX / 10f, 10f, transform.position.z);

            // ワールド座標からビューポート座標に変換
            viewportPosition = Camera.main.WorldToViewportPoint(newPosition);

            // ビューポート座標を制限して、ビューポート内に収める
            viewportPosition.x = Mathf.Clamp01(viewportPosition.x);

            // ビューポート座標からワールド座標に戻す
            Vector3 worldPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            // オブジェクトを新しい位置に移動
            transform.position = worldPosition;
        }
    }
}
