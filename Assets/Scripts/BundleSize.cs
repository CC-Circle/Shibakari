using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BundleSize : MonoBehaviour
{
    public int Flag=0,COUNT=0,i=0;

    public GameObject grass; // プレハブの参照
    public string tagToAssign = "grass"; // タグの名前

    public TextMeshProUGUI Score;

    float score;

    void Start()
    {
        COUNT=CutMove.Score/500;
        if(CutMove.Score%500!=0){
            COUNT+=1;
        }
        Debug.Log(COUNT);
    }

    void Update()
    {
        if(Flag==1 && i<=COUNT-1){//フラグが立っていれば
            Debug.Log(i);
            Flag=0;
            // プレハブからオブジェクトを生成
            GameObject obj = Instantiate(grass, new Vector3(0, 10, 0), Quaternion.identity);
            // オブジェクトにタグを付ける
            obj.tag = tagToAssign;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (collision.gameObject.CompareTag("grass"))
        {
            Flag=1;//フラグを立てる
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f); // x、y、z方向それぞれに0.4ずつサイズを増加させる
            i++;
            if(i==1){
                 score+=CutMove.Score%500;
            }else{
                score+=500;
            }
            //単位をつけて代入
            if(score<1000){
                Score.text = Mathf.FloorToInt(score).ToString("F0") + "g";
            }else{
                Score.text = (score / 1000f).ToString("F1") + "kg";
            }
        }
    }
}
