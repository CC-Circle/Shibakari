using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraManager : MonoBehaviour
{
    public Transform blockParent;
    public GameObject blockPrefab_Mogura;
    CollisionDetection collisionDetection;

    public const int MAP_WIDTH = 500;
    public const int MAP_HEIGHT = 500;

    Vector3 defaultPos = new Vector3(0.0f, 1.0f, 0.0f);

    void Start()
    {
        collisionDetection = FindObjectOfType<CollisionDetection>();

        defaultPos.x = -(MAP_WIDTH / 2);
        defaultPos.z = -(MAP_HEIGHT / 2);
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = defaultPos;
            pos.x += Random.Range(0, MAP_WIDTH);
            pos.z += Random.Range(0, MAP_HEIGHT);
            pos.y = 1.0f;
            GameObject block = Instantiate(blockPrefab_Mogura, pos, Quaternion.identity, blockParent);
            block.transform.parent = blockParent;
        }
    }

    void Update()
    {
        if (collisionDetection.isMoguraDestory == 1)
        {
            Debug.Log("Generating new mole");

            // 新たにもぐらを生成
            Vector3 pos = defaultPos;
            pos.x += Random.Range(0, MAP_WIDTH);
            pos.z += Random.Range(0, MAP_HEIGHT);
            pos.y = 1.0f;
            GameObject block = Instantiate(blockPrefab_Mogura, pos, Quaternion.identity);
            block.transform.SetParent(blockParent, true);

            // フラグをリセット
            collisionDetection.isMoguraDestory = 0;

        }
    }
}