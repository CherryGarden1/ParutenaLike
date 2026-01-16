using UnityEngine;

public class ExplosionFollowScroll : MonoBehaviour
{
	public float scrollSpeed = 10f; // WorldScrollManager ‚Æ“¯‚¶’l
	public float lifeTime = 1.5f;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	void Update()
	{
		transform.localScale += Vector3.one * scrollSpeed * Time.deltaTime;
	}
}
