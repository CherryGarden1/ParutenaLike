using UnityEngine;

public class StageEnd : MonoBehaviour
{
	[SerializeField]
	private GameObject Player;//ëfçﬁéwíË
	public event System.Action NextStage;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Hit:" + other.name);
	}
}
