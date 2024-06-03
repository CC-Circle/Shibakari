using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main2End : MonoBehaviour
{
    public TimeCounter timeCounter;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // 経過時間が0になったらシーンを変更
        if (timeCounter.countdownSec <= 0)
        {
            ChangeScene();
        }
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene("end");
    }
}
