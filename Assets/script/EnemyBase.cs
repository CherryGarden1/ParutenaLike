using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	public int hp = 10;

	// BlastManager が受け取るイベント
	public static event Action<Vector3, EnemyBase> OnEnemyExploded;

	public GameObject explosionPrefab;

	// ------------------------------------
	// damage を受ける
	// ------------------------------------
	public virtual void TakeDamage(int damage, bool isBlastDamage = false)
	{
		hp -= damage;

		if (hp <= 0)
		{
			Die(isBlastDamage);
		}
	}

	// ------------------------------------
	// 死亡処理
	// ------------------------------------
	private void Die(bool isBlastDamage)
	{
		// ① まず爆発処理（エフェクト & BlastManager への通知）
		Explode();

		// ② Blast由来なら連鎖起動
		if (isBlastDamage)
		{
			GetComponent<ChainExplosion>()?.StartChain();
		}

		// ③ 最後に敵を削除
		Destroy(gameObject);
	}

	// ------------------------------------
	// 爆発処理（イベントも含む）
	// ------------------------------------
	private void Explode()
	{
		if (explosionPrefab)
		{
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}

		// 連鎖爆発マネージャーに通知
		OnEnemyExploded?.Invoke(transform.position, this);
	}
}
