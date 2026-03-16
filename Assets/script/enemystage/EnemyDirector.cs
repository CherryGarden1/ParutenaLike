using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
	public static EnemyDirector Instance;

	[SerializeField] EnemyFormationSpawner spawner;
	[SerializeField] EnemySpawnLine spawnLine;
	[SerializeField] List<EnemyFormationData> formationList;
	[SerializeField] float spawnCooldown = 10f; // ŽŸ‚Ì•Ò‘à‚Ü‚Å‚ÌŽžŠÔ

	int aliveEnemy;
	bool spawning;
	int formationIndex = 0;
	void Awake()
	{
		Instance = this;
	}

	public void RegisterEnemy()
	{
		aliveEnemy++;
	}

	public void UnregisterEnemy()
	{
		aliveEnemy--;

		if (aliveEnemy <= 2 && !spawning)
		{
			StartCoroutine(SpawnDelay());
		}
	
	}
	IEnumerator SpawnDelay()
	{
		spawning = true;

		yield return new WaitForSeconds(spawnCooldown);

		SpawnNext();

		spawning = false;
	}

	void SpawnNext()
	{
		if (formationIndex >= formationList.Count)
		{
			StageClear();
			return;
		}
		Vector3 pos = spawnLine.GetSpawnPosition();
		spawner.SpawnNext(pos);
		formationIndex++;
	}
	void StageClear()
	{
		Debug.Log("STAGE CLEAR");
	}
}
