using UnityEngine;

public class StageEnd : MonoBehaviour
{
	[SerializeField]
	private GameObject Player;//素材指定
	public event System.Action NextStage;
	private void OnTriggerEnter(Collider other)
	{
		// プレイヤーかどうかを確認
		if (other.CompareTag("Player"))
		{
			NextStage?.Invoke();
		}
	}
}
