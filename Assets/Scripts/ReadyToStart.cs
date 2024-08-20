using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ReadyToStart : MonoBehaviour
{
    public AudioSource StartSound;
    public static bool flag = false;
    public TextMeshProUGUI ReadyText;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        StartSound = GetComponent<AudioSource>();

        // シーンが読み込まれたらサウンドを再生
        PlaySound();
    }
    void Update()
    {
        //4秒後にflagをTrueにする
        if (Time.timeSinceLevelLoad >= 3)
        {
            flag = true;
            ReadyText.text = "Start!";
            if (Time.timeSinceLevelLoad > 5)
            {
                ReadyText.text = "";
            }
        }
        else
        {
            // カウントダウンを表示
            ReadyText.text = Mathf.FloorToInt(4 - Time.timeSinceLevelLoad).ToString("F0");
        }

        // Debug.Log(flag);
    }

    void PlaySound()
    {
        StartSound.Play();
    }
}
