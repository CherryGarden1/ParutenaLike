using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationSpawner : MonoBehaviour
{
	[SerializeField] EnemyFormationManager formationPrefab;
	[SerializeField] EnemyFormationData[] formationList;

	List<EnemyFormationData> unusedFomations;

	 void Awake()
	{
		//敵の設計図呼び出し
		unusedFomations = new List<EnemyFormationData>(formationList);
		//Debug.Log($"Spawner Awake / formations = {unusedFomations.Count}");

	}
	void Start()
	{
		// ★ テスト用：開始1秒後に必ず出す
		Invoke(nameof(TestSpawn), 1f);
	}

	void TestSpawn()
	{
		SpawnNext(transform.position);//次の編隊
	}
	public void SpawnNext(Vector3 position)
	{
		//Debug.Log("SpawnNext called");
		if (unusedFomations.Count == 0)
		{
			//Debug.Log("All used");
			return;
		}
		int index = Random.Range(0,unusedFomations.Count);
		EnemyFormationData data = unusedFomations[index];
		unusedFomations.RemoveAt(index);

		EnemyFormationManager fomation =
			Instantiate(formationPrefab, position, Quaternion. identity);

		fomation.Init(data);
		//Debug.Log($"Spawned formation: {data.name}");
	}
}
