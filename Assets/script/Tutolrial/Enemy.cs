using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public static event Action OnEnemyDestroyed;

	public void Die()
	{
		OnEnemyDestroyed?.Invoke();
		Destroy(gameObject);
	}
}