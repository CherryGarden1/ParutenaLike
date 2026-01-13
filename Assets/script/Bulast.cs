using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bulast : MonoBehaviour
{
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private Rigidbody rb;
	[SerializeField]
	GameObject firePoint;
	public float explosionRadius = 10f;  // 最初の爆発範囲
	public float chainDelay = 0.2f;      // 連鎖までの遅延
	public int maxChains = 5;            // 最大連鎖回数
	public int Exdamage = 50;           // 連鎖爆発用ダメージ

	// 連鎖済み敵を記録して二重処理を防ぐ
	private HashSet<Transform> explodedEnemies = new HashSet<Transform>();

	[SerializeField]
	GameObject explosionPrefab;

	void Start()
	{
		// 発射方向は生成されたときの forward
		if (rb != null)
		{


			rb.linearVelocity = transform.forward * bulletSpeed; // Unity 6系
																 // rb.velocity = transform.forward * bulletSpeed;   // Unity 2023以前
		}


		// 5秒後に自動消滅
		Destroy(gameObject, 5f);
	}
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log($"Bullet hit:{other.name},tag = {other.name}");
		if (other.CompareTag("Enemy"))
		{
			Debug.Log("Hit Enemy!");
			EnemyBase enemy = other.GetComponent<EnemyBase>();
			//Debug.Log($"Enemy Base commponent:{(enemy!=null ? "found" : "null")}");
			if (enemy)
			{
				enemy.TakeDamage(Exdamage, isBlastDamage: true); // 最初の爆発だけ起動
				//Debug.Log($"Called TakeDamege({Exdamage}) on {other.name}");
			}

			Destroy(gameObject);
		}

	}
}
