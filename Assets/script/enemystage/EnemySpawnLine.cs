using UnityEngine;

public class EnemySpawnLine : MonoBehaviour
{
	[SerializeField] float spawnZ = 120f;

	public Vector3 GetSpawnPosition()
	{
		Vector3 pos = new Vector3(
			Random.Range(-25f, 25f),
			Random.Range(-8f, 8f),
			spawnZ
		);//

		return pos;
	}
}