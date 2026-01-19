using UnityEngine;

public class CameraFllow : MonoBehaviour
{

	public float speed = 20f;

	void Update()
	{
		transform.position += Vector3.forward * speed * Time.deltaTime; 

	}
}


