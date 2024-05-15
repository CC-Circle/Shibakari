using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public float transitionDuration = 10.0f;

    private float transitionTime = 0f;
    private bool isTransitioning = false;
    private bool isDayToNight = false;

    void Start()
    {
        // Skyboxの初期設定を昼（daySkybox）に設定
        RenderSettings.skybox = daySkybox;
    }

    void Update()
    {
        if (isTransitioning)
        {
            transitionTime += Time.deltaTime;
            // トランジションの進行度を0〜1の範囲にクランプ
            float t = Mathf.Clamp01(transitionTime / transitionDuration);

            // 昼 -> 夜 or 夜 -> 昼
            // 条件分岐によって，skyboxを設定
            RenderSettings.skybox = isDayToNight ?
                BlendSkybox(daySkybox, nightSkybox, t) :
                BlendSkybox(nightSkybox, daySkybox, t);
            Debug.Log("The transition is in progress");


            // トランジションが完了したら実行
            if (t >= 1f)
            {
                isTransitioning = false;
                transitionTime = 0f;
                Debug.Log("The transition is completed");
            }
        }

        // テスト用
        // 現在は手動でskyboxの遷移を行うが最終的には自動的に変更したい
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTransition();
        }
    }

    public void StartTransition()
    {
        isTransitioning = true;
        transitionTime = 0f;
        // 昼か夜かを保存する変数の値切り替え
        isDayToNight = !isDayToNight;
    }

    // 2つのスカイボックスを線形補間して混合する
    private Material BlendSkybox(Material skybox1, Material skybox2, float t)
    {
        Material blendedSkybox = new Material(skybox1);
        blendedSkybox.Lerp(skybox1, skybox2, t);
        return blendedSkybox;
    }
}
