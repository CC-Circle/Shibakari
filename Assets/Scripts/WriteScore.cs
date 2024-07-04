using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteScore : MonoBehaviour
{
    GameObject Shibakari; //Shibakariそのものが入る変数

    OperationSettings OperationSettings; //CutMoveが入る変数

    public TextMeshProUGUI Score;


    void Start () {
        Shibakari = GameObject.Find ("Shibakari"); //Shibakariをオブジェクトの名前から取得して変数に格納する
        OperationSettings = Shibakari.GetComponent<OperationSettings>(); //Shibakariの中にあるCutMoveを取得して変数に格納する
    }

    void Update () {
        //単位をつけて代入
        if(OperationSettings.Score<1000){
            Score.text = Mathf.FloorToInt(OperationSettings.Score).ToString("F0") + "g";
        }else{
            Score.text = (OperationSettings.Score / 1000f).ToString("F1") + "kg";
        }
    }
}
