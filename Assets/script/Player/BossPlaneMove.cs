using UnityEngine;

public class BossPlaneMove : MonoBehaviour
{
	[SerializeField]
	float speed = 10f;
	[SerializeField]
	Vector2 limit = new Vector2(8f, 5f);

	Rigidbody rb;

	 void Awake()
	{
		rb= GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	 void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		//動かすメイン
		Vector3 move = new Vector3(x,y,0) * speed * Time.deltaTime;
		Vector3 next = rb.position + move;

		//ボス戦用画面内制限
		Vector3 camPos = Camera.main.transform.position;
		next.x = Mathf.Clamp(next.x, camPos.x - limit.x, camPos.x + limit.x);
		next.y = Mathf.Clamp(next.y, camPos.y - limit.y, camPos.y + limit.y);

		rb.MovePosition(next);
	}
}
