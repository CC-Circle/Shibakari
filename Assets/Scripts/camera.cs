using System.Collections.Generic;
using UnityEngine;
 
public class CameraSample : MonoBehaviour {
 
    private GameObject player;   // プレイヤー情報格納用
    private Vector3 offset;      // 相対距離取得用
 
    // Use this for initialization
    void Start () {
        // Shibakariの情報を取得
        this.player = GameObject.Find("Shibakari");
 
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;

        // x座標を固定する（-0.3719021に固定）
        offset.x = -0.3719021f; // float型のリテラルとして表記するためにfを付けます
    }
 
    // LateUpdate is called after Update each frame
    void LateUpdate () {
        // プレイヤーの位置にoffsetを加えた値でカメラの位置を設定する
        Vector3 newPosition = player.transform.position + offset;

        // xの値を固定するために最初に設定したxの値を代入
        transform.position = new Vector3(offset.x, newPosition.y, newPosition.z);
    }
}
