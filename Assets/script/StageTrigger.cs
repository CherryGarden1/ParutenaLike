using UnityEngine;

public class StageTrigger : MonoBehaviour
{
	[SerializeField] GameObject stagePrefab;
	[SerializeField] float spawnDistance = 200f;

	bool spawned = false;

	private void OnTriggerEnter(Collider other)
	{
		if (spawned) return;

		if (other.CompareTag("Player"))
		{
			spawned = true;

			GameObject copy = Instantiate(stagePrefab, WorldScrollManager.Instance.transform);

			Vector3 spawnPos = transform.parent.position;
			spawnPos.z += spawnDistance;
			copy.transform.position = spawnPos;

			Debug.Log("Stage Spawned");
		}
	}
}
