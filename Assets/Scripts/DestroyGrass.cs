using UnityEngine;

public class DestroyGrass : MonoBehaviour
{
    private GameObject objectToDestroy = null;//草に触れたかどうかの判定フラグ
    public static int Score;//スコアの変数


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        // 衝突したオブジェクトが "grass" タグを持っているか確認
        if (other.gameObject.CompareTag("grass"))
        {
            // オブジェクトを消すフラグを立てる
            objectToDestroy = other.gameObject;
        }
    }

    void Update()
    {
        if (objectToDestroy != null)
        {
            //オブジェクトを消す
            Destroy(objectToDestroy);
            objectToDestroy = null;
            Score += 100;
        }
    }
}
