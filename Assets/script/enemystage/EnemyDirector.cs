using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
	public static EnemyDirector Instance;

	[SerializeField] EnemyFormationSpawner spawner;
	[SerializeField] EnemySpawnLine spawnLine;

	int aliveEnemy;
	bool spawning;

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
			SpawnNext();
		}
	}

	void SpawnNext()
	{
		Vector3 pos = spawnLine.GetSpawnPosition();
		spawner.SpawnNext(pos);
	}
}
