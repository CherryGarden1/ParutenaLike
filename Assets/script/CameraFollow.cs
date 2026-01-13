using UnityEngine;

public class CameraFllow : MonoBehaviour
{

	[SerializeField] private Transform player;   // プレイヤー機体
	[SerializeField] private Vector3 offset = new Vector3(0, 3f, -10f);
	[SerializeField] private float smoothSpeed = 5f;

	void LateUpdate()
	{
		if (player == null) return;

		// 目標位置（プレイヤーから見て後ろ＆上にオフセット）
		Vector3 targetPosition = player.position + offset;

		// カメラをスムーズに追従
		float t = Mathf.Clamp01(smoothSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targetPosition, t);

		// 注視するのは「プレイヤーの少し前方」
		
		transform.LookAt(player.position);

	}
}


