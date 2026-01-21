using UnityEngine;

public class BossPlaneMove : MonoBehaviour
{
	[SerializeField]
	float speed = 10f;
	[SerializeField]
	Vector2 limit = new Vector2(8f, 5f);

	Rigidbody rb;
	private PlayerCore core;
	 void Awake()
	{
		core = GetComponentInParent<PlayerCore>();
		rb= GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;

		if(core == null)
		{
			Debug.LogError(
				$"{name}:PlayerCore not found.Parent hierarchy is wrong."
				);
		}
	}

	// void FixedUpdate()
	//{
	//	if (core == null) return;
	//	if (core.isTransforming)
	//	{
	//		float x = Input.GetKey(KeyCode.A) ? -1 :
	//			Input.GetKey(KeyCode.D) ? 1 : 0;
	//		float y = Input.GetKey(KeyCode.W) ? -1 :
	//					Input.GetKey(KeyCode.S) ? 1 : 0;
	//		//動かすメイン
	//		Vector3 move = new Vector3(x, y, 0) * speed * Time.deltaTime;
	//		Vector3 next = rb.position + move;
	//
	//		//ボス戦用画面内制限
	//		Vector3 camPos = Camera.main.transform.position;
	//		next.x = Mathf.Clamp(next.x, camPos.x - limit.x, camPos.x + limit.x);
	//		next.y = Mathf.Clamp(next.y, camPos.y - limit.y, camPos.y + limit.y);
	//
	//		rb.MovePosition(next);
	//
	//		return;
	//	}
	//}

	void FixedUpdate()
	{
		if (!gameObject.activeInHierarchy) return;
		if (core.isInvincible == false && core.currentHP <= 0) return;

		float x = 0;
		float y = 0;

		if (Input.GetKey(KeyCode.A)) x = -1;
		if (Input.GetKey(KeyCode.D)) x = 1;
		if (Input.GetKey(KeyCode.W)) y = 1;
		if (Input.GetKey(KeyCode.S)) y = -1;

		Vector3 move = new Vector3(x, y, 0).normalized * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + move);
	}
}
