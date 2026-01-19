using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField]public float maxRadius = 10f;
	[SerializeField]public float expandSpeed = 5f;
	[SerializeField] public float lifeTime = 5f;
	[SerializeField] int damage = 50;
	public LayerMask enemyLayer;
	private float currentRadius = 0f;
	private float timer = 0f;
	private Material mat;
	private Color baseColor;

	// すでに巻き込んだ敵（多段ヒット防止）
	private HashSet<EnemyBase> damaged = new HashSet<EnemyBase>();

	void Start()
	{
		mat = GetComponent<Renderer>().material;
		baseColor = mat.color;
	}

	void Update()
	{
		timer += Time.deltaTime;

		// 拡大
		currentRadius += expandSpeed * Time.deltaTime;

		//  上限を強制
		currentRadius = Mathf.Min(currentRadius, maxRadius);

		transform.localScale = Vector3.one * currentRadius;

		// 後半だけフェード
		float fadeStart = lifeTime * 0.5f;
		if (timer > fadeStart)
		{
			float t = 1f - (timer - fadeStart) / (lifeTime - fadeStart);
			mat.color = new Color(
				baseColor.r,
				baseColor.g,
				baseColor.b,
				Mathf.Clamp01(t * baseColor.a)
			);
		}
		ApplyDamage();
		if (timer >= lifeTime)
			Destroy(gameObject);
	}
	void ApplyDamage()
	{
		Collider[] hits = Physics.OverlapSphere(
			transform.position,
			currentRadius,
			enemyLayer
		);

		foreach (var hit in hits)
		{
			EnemyBase enemy = hit.GetComponent<EnemyBase>();
			if (enemy != null && !damaged.Contains(enemy))
			{
				damaged.Add(enemy);
				enemy.TakeDamage(damage, true); // ← Blust判定
			}
		}
	}
}
