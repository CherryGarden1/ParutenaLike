
using UnityEngine;

public class EnemyFlyBy : EnemyBase
{
	public float speed = 25f;

	void Update()
	{
		transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
	}
}