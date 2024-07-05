using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoleDetector : MonoBehaviour
{
    public Image MoleImage; // Imageオブジェクト
    public float displayDuration = 2.0f; // 画像を表示する時間（秒）
    public float detectionRange = 10.0f; // 検出範囲（メートル）

    void Start()
    {
        if (MoleImage != null)
        {
            MoleImage.gameObject.SetActive(false); // 最初は非表示にする
        }
    }

    void Update()
    {
        DetectMoleInCameraView();
    }

    void DetectMoleInCameraView()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Mole"))
            {
                StartCoroutine(ShowImage());
            }
        }
    }

    IEnumerator ShowImage()
    {
        if (MoleImage != null)
        {
            MoleImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(displayDuration);
            MoleImage.gameObject.SetActive(false);
        }
    }
}
