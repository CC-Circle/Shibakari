using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    public Transform blockParent_Grass;
    public Transform blockParent_Mole;

    [Header("草")]
    public GameObject blockPrefab_Grass;

    [Header("もぐら")]
    public GameObject blockPrefab_Mole;

    public const int MAP_WIDTH = 500;
    public const int MAP_HEIGHT = 500;

    void Start()
    {
        Vector3 defaultPos = new Vector3(0.0f, 13.5f, 0.0f);
        defaultPos.x = -(MAP_WIDTH / 2);
        defaultPos.z = -(MAP_HEIGHT / 2);


        // ここがワールドのブロックのパターンを生成するところ
        for (int i = 0; i < MAP_WIDTH; i += 40)
        {
            for (int j = 0; j < MAP_HEIGHT; j += 40)
            {
                Vector3 pos = defaultPos;
                pos.x += i;
                pos.z += j;

                GameObject obj;

                if(Random.Range(1, 100) <= 2){
                    obj = Instantiate(blockPrefab_Mole, blockParent_Grass);
                    obj.transform.position = pos;
                }else{
                    obj = Instantiate(blockPrefab_Grass, blockParent_Mole);
                    pos.y-=2;
                    obj.transform.position = pos;
                }
            }
        }
    }
}