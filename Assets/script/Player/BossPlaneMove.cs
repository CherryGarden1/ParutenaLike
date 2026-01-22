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
		rb= GetComponentInParent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;

		if(core == null)
		{
			Debug.LogError(
				$"{name}:PlayerCore not found.Parent hierarchy is wrong."
				);
		}
	}

	public void HandleInput()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(x, y, 0f);
		rb.MovePosition(rb.position + move * speed * Time.deltaTime);
	}
}
