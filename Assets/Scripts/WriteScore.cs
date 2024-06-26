using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteScore : MonoBehaviour
{
    GameObject Shibakari; //Shibakariそのものが入る変数

    DestroyGrass DestroyGrass; //CutMoveが入る変数

    public TextMeshProUGUI Score;


    void Start () {
        Shibakari = GameObject.Find ("Shibakari"); //Shibakariをオブジェクトの名前から取得して変数に格納する
        DestroyGrass = Shibakari.GetComponent<DestroyGrass>(); //Shibakariの中にあるCutMoveを取得して変数に格納する
    }

    void Update () {
        //単位をつけて代入
        if(DestroyGrass.Score<1000){
            Score.text = Mathf.FloorToInt(DestroyGrass.Score).ToString("F0") + "g";
        }else{
            Score.text = (DestroyGrass.Score / 1000f).ToString("F1") + "kg";
        }
    }
}
