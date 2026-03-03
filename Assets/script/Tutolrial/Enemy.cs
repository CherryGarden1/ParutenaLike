using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public static event Action OnEnemyDestroyed;

	public void Die()
	{
		Debug.Log("Die");
		OnEnemyDestroyed?.Invoke();
		Destroy(gameObject);
	}
}