using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
	public Transform blockParent;
	public GameObject blockPrefab_Grass;

	public const int MAP_WIDTH = 500;
	public const int MAP_HEIGHT = 500;

	void Start()
	{
		Vector3 defaultPos = new Vector3(0.0f, 10.0f, 0.0f);
		defaultPos.x = -(MAP_WIDTH / 2);
		defaultPos.z = -10;


		// ここがワールドのブロックのパターンを生成するところ
		for (int i = 0; i < MAP_WIDTH; i+=10)
		{
			for (int j = 0; j < MAP_HEIGHT; j+=10)
			{
				Vector3 pos = defaultPos;
				pos.x += i;
				pos.z += j;

				GameObject obj;
				obj = Instantiate(blockPrefab_Grass, blockParent);
				obj.transform.position = pos;
			}
		}
	}

	void Update()
	{
	}
}