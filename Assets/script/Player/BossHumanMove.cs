using UnityEngine;

public class BossHumanMove : MonoBehaviour
{
	[SerializeField] float speed = 8f;
	[SerializeField] float verticalSpeed = 6f;
	[SerializeField] Vector2 limit = new Vector2(6f, 4f);

	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		float up = 0f;

		if (Input.GetKey(KeyCode.Q)) up = 1f;
		if (Input.GetKey(KeyCode.E)) up = -1f;

		Vector3 move = new Vector3(x, up, y) * speed * Time.fixedDeltaTime;
		Vector3 next = rb.position + move;

		Vector3 camPos = Camera.main.transform.position;
		next.x = Mathf.Clamp(next.x, camPos.x - limit.x, camPos.x + limit.x);
		next.y = Mathf.Clamp(next.y, camPos.y - limit.y, camPos.y + limit.y);

		rb.MovePosition(next);
	}
}
