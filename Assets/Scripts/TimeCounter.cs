using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TimeCounter : MonoBehaviour
{
    public float countdownSec = 40;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownSec -= Time.deltaTime;
        timeText.text = countdownSec.ToString();
    }
}
