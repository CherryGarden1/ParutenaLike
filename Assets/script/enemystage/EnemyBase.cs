using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	[SerializeField]
	private GameObject ExplosionSphere;
	public int hp = 10;

	// BlastManager が受け取るイベント
	public static event Action<Vector3, EnemyBase> OnEnemyExploded;

	//public GameObject explosionPrefab;

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
		if (ExplosionSphere)
		{

			GameObject fx = Instantiate(ExplosionSphere,
				transform.position,
				Quaternion.identity
			);
			//親を外す
			fx.transform.SetParent(null);
		}
		

		// 連鎖爆発マネージャーに通知
		OnEnemyExploded?.Invoke(transform.position, this);
		//オブジェクト破壊0.05s遅らせ
		Destroy(gameObject,0.05f);
	}
}
