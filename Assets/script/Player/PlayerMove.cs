using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	[SerializeField] private float speed = 10f;
	[SerializeField] private Vector2 limit = new Vector2(8f, 5f);
	[SerializeField] private float downlimitRatio = 0.4f;

	public Vector3 currentVelocity { get; private set; }

	private Rigidbody rb;
	private Vector3 lastPosition;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(x, y, 0f).normalized * speed * Time.fixedDeltaTime;
		Vector3 nextPos = rb.position + movement;

		// カメラ基準のローカル座標へ変換
		Vector3 localPos = Camera.main.transform.InverseTransformPoint(nextPos);

		// カメラから見た左右・上下を制限
		localPos.x = Mathf.Clamp(localPos.x, -limit.x, limit.x);
		localPos.y = Mathf.Clamp(
			localPos.y, -limit.y * downlimitRatio,
			limit.y);

		// ワールド座標へ戻す
		nextPos = Camera.main.transform.TransformPoint(localPos);

		rb.MovePosition(nextPos);

		currentVelocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
		lastPosition = transform.position;
	}
}
