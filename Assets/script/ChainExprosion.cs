using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainExplosion : MonoBehaviour
{

	[Header("Chain Settings")]
	public float explosionRadius = 10f;
	public float chainDelay = 0.2f;
	public int chainDamage = 50;

	[Header("Debug")]
	public bool drawGizmo = true;

	// すでに巻き込んだ敵を記録（無限ループ防止）
	private static HashSet<EnemyBase> explodedEnemies = new HashSet<EnemyBase>();

	// ------------------------------------
	// EnemyBase から呼ばれる起点
	// ------------------------------------
	public void StartChain()
	{
		StartCoroutine(ExplosionRoutine(transform.position));
	}

	// ------------------------------------
	// 連鎖爆発処理
	// ------------------------------------
	private IEnumerator ExplosionRoutine(Vector3 originPos)
	{
		yield return new WaitForSeconds(chainDelay);

		Collider[] hits = Physics.OverlapSphere(
			originPos,
			explosionRadius,
			LayerMask.GetMask("Enemy")
		);

		foreach (Collider hit in hits)
		{
			EnemyBase enemy = hit.GetComponent<EnemyBase>();
			if (enemy == null) continue;

			// すでに爆発済みならスキップ
			if (explodedEnemies.Contains(enemy)) continue;

			explodedEnemies.Add(enemy);

			// Blast ダメージとして処理
			enemy.TakeDamage(chainDamage, true);
		}
	}

	// ------------------------------------
	// デバッグ用 可視化
	// ------------------------------------
	private void OnDrawGizmosSelected()
	{
		if (!drawGizmo) return;

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}

