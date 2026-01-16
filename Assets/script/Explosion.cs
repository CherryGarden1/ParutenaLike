using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float maxRadius = 10f;
	public float expandSpeed = 30f;
	public float lifeTime = 0.3f;

	private float currentRadius = 0f;
	private Material mat;
	private Color baseColor;

	void Start()
	{
		mat = GetComponent<Renderer>().material;
		baseColor = mat.color;
		Destroy(gameObject, lifeTime);
	}

	void Update()
	{
		currentRadius += expandSpeed * Time.deltaTime;
		float scale = currentRadius * 2f;
		transform.localScale = Vector3.one * scale;

		// フェードアウト
		float t = 1f - (currentRadius / maxRadius);
		mat.color = new Color(
			baseColor.r,
			baseColor.g,
			baseColor.b,
			Mathf.Clamp01(t * baseColor.a)
		);
	}
}
