using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public float countdownSec = 0;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //時間を減らしてます
        countdownSec -= Time.deltaTime;
        //小数点以下を非表示に変更して代入
        timeText.text = "TIME : " + Mathf.FloorToInt(countdownSec).ToString("F0");

        if (countdownSec <= 0)//カウント0になったらリザルトへ
        {
            SceneManager.LoadScene("end");
        }
    }
}
