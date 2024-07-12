using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoleDetector : MonoBehaviour
{
    public Image MoleImage; // モグラの画像を表示するためのImageオブジェクト
    public float displayDuration = 2.0f; // 画像を表示する時間（秒）
    public float detectionRange = 10.0f; // モグラを検出する範囲（メートル）

    // 初期化処理
    void Start()
    {
        // MoleImageが設定されている場合、最初は非表示にする
        if (MoleImage != null)
        {
            MoleImage.gameObject.SetActive(false);
        }
    }

    // 毎フレーム呼ばれる処理
    void Update()
    {
        DetectMoleInCameraView(); // カメラビュー内でモグラを検出する
    }

    // カメラビュー内でモグラを検出する関数
    void DetectMoleInCameraView()
    {
        // 画面中央からレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        // レイキャストを行い、モグラにヒットした場合
        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Mole"))
            {
                StartCoroutine(ShowImage()); // 画像を表示するコルーチンを開始
            }
        }
    }

    // 画像を表示し、一定時間後に非表示にするコルーチン
    IEnumerator ShowImage()
    {
        if (MoleImage != null)
        {
            MoleImage.gameObject.SetActive(true); // 画像を表示
            yield return new WaitForSeconds(displayDuration); // 指定した時間待つ
            MoleImage.gameObject.SetActive(false); // 画像を非表示にする
        }
    }
}
