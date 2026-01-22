using UnityEngine;

public class BossHumanCamera : MonoBehaviour
{
	[SerializeField] Transform playerRoot;   // PlayerBossRoot
	[SerializeField] Transform humanModel;   // HumanForm_Boss

	[Header("Offset")]
	[SerializeField] Vector3 offset = new Vector3(0, 2.5f, -6f);

	[Header("Smooth")]
	[SerializeField] float positionSmooth = 6f;
	[SerializeField] float rotationSmooth = 6f;

	void LateUpdate()
	{
		if (playerRoot == null || humanModel == null) return;

		// ===== 位置：キャラ向き基準で後方 =====
		Vector3 targetPos =
			playerRoot.position
			+ humanModel.rotation * offset;

		transform.position = Vector3.Lerp(
			transform.position,
			targetPos,
			Time.deltaTime * positionSmooth
		);

		// ===== 注視点：少し上を見る =====
		Vector3 lookTarget =
			playerRoot.position + Vector3.up * 1.5f;

		Quaternion targetRot =
			Quaternion.LookRotation(lookTarget - transform.position);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			targetRot,
			Time.deltaTime * rotationSmooth
		);
	}
}
