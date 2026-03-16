using UnityEngine;

public class EnemyDespawnLine : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
		}
	}
}