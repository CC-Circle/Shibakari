using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BundleSize : MonoBehaviour
{
    public int Flag=0,COUNT=0;

    public GameObject grass; // プレハブの参照
    public string tagToAssign = "grass"; // タグの名前

    public TextMeshProUGUI Score;

    float score;

    void Update()
    {
        if(Flag==1){//フラグが立っていれば
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); // x、y、z方向それぞれに0.4ずつサイズを増加させる
            if(COUNT%20==0){
                transform.position += new Vector3(0, 1, 0);
            }
            Flag=0;
        }
        Debug.Log(DestroyGrass.Score/10);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (collision.gameObject.CompareTag("grass"))
        {
            if(COUNT<=DestroyGrass.Score/10){
                Destroy(collision.gameObject);
                Flag=1;//フラグを立てる
                COUNT++;//何回か数える
                // プレハブからオブジェクトを生成
                GameObject obj = Instantiate(grass, new Vector3(0, 10, 0), Quaternion.identity);
                // オブジェクトにタグを付ける
                obj.tag = tagToAssign;
                score+=100;
                //単位をつけて代入
                if(score<1000){
                    Score.text = Mathf.FloorToInt(score).ToString("F0") + "g";
                }else{
                    Score.text = (score / 1000f).ToString("F1") + "kg";
                }
            }
        }
    }
}
