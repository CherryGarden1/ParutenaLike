using UnityEditor.PackageManager;
using UnityEngine;

public class BossHumanMove : MonoBehaviour
{
	[Header("Move")]
	[SerializeField] float speed = 8f;
	[SerializeField] float verticalSpeed = 6f;
	//[Header("Limit")]
	//[SerializeField] float minY = -3f;
	//[SerializeField] float maxY = 5f;

	Rigidbody rb;
	private PlayerCore core;

	void Awake()
	{
		core = GetComponentInParent<PlayerCore>();
		rb = GetComponentInParent<Rigidbody>();


		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}


	public void HandleInput()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		float z = 0f;

			if(Input.GetKey(KeyCode.Q)) z = 1f;
		if (Input.GetKey(KeyCode.E)) z = -1f;

		Vector3 move = new Vector3(x, y, z);
		rb.MovePosition(rb.position + move * speed * Time.deltaTime);
	}
}
