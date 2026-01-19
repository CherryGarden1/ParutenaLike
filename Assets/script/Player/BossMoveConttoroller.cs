using UnityEngine;

public class BossMoveConttoroller : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 10f;

	void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Vector3 move = new Vector3(h, v, 0f).normalized;
		transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
	}
}
