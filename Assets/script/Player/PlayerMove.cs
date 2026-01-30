using UnityEngine;

public class PlaneMove : MonoBehaviour
{

	[SerializeField] private float speed = 10f;
	[SerializeField] private Vector2 limit = new Vector2(8f, 5f);
	[SerializeField] private float downlimitRatio = 0.4f;

	public Vector3 currentVelocity { get; private set; }

	private Rigidbody rb;
	private Vector3 lastPosition;

	void Start()
	{
		//rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
	}

	public void HandleInput(Vector2 input)
	{
		
		Vector3 movement = new Vector3(input.x, input.y, 0f).normalized * speed * Time.fixedDeltaTime;
		Vector3 nextPos = rb.position + movement;

		Vector3 localPos = Camera.main.transform.InverseTransformPoint(nextPos);
		localPos.x = Mathf.Clamp(localPos.x, -limit.x, limit.x);
		localPos.y = Mathf.Clamp(localPos.y, -limit.y * downlimitRatio, limit.y);
		nextPos = Camera.main.transform.TransformPoint(localPos);

		rb.MovePosition(nextPos);
		Debug.Log("PlayerMove HandleInput");

	}

	void FixedUpdate()
	{
		
		currentVelocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
		lastPosition = transform.position;
	}
}
