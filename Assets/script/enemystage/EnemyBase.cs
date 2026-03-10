using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	[SerializeField]
	private GameObject ExplosionSphere;
	public int hp = 10;

	// BlastManager が受け取るイベント
	public static event Action<Vector3, EnemyBase> OnEnemyExploded;

	void Start()
	{
		EnemyDirector.Instance.RegisterEnemy();
	}

	// ------------------------------------
	// damage を受ける
	// ------------------------------------
	public virtual void TakeDamage(int damage, bool isBlastDamage = false)
	{
		hp -= damage;

		if (hp <= 0)
		{
			Die(isBlastDamage);
			gameObject.AddComponent<Enemy>().Die();
		}
	}

	// ------------------------------------
	// 死亡処理
	// ------------------------------------
	private void Die(bool isBlastDamage)
	{
		// ① まず爆発処理（エフェクト & BlastManager への通知）
		PlayExplosionEffect();

		// ② Blast由来なら連鎖起動
		if (isBlastDamage)
		{
			OnEnemyExploded?.Invoke(transform.position, this);
		}

		// ③ 最後に敵を削除
		Destroy(gameObject);
	}

	private void PlayExplosionEffect()
	{
		if (ExplosionSphere)
		{
			GameObject fx = Instantiate(
				ExplosionSphere,
				transform.position,
				Quaternion.identity
			);
			fx.transform.SetParent(null);
		}
	}
}
