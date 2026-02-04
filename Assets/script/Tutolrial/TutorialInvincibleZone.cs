using UnityEngine;

public class TutorialInvincibleZone : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerCore>()?.SetInvincible(999f);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerCore>()?.SetInvincible(0f);
		}
	}
}
