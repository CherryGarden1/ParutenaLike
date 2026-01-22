using UnityEngine;

public class BossCameraPlaneFollow : MonoBehaviour
{
	[SerializeField] Transform playerRoot;//PlayerBossRoot
	[SerializeField] Transform planeModel;//PlayerForm_Boss
	[SerializeField] Vector3 offset = new Vector3(0, 3f, -10f);
	[SerializeField] float positionSmooth = 5f;
	[SerializeField] float rotationSmooth = 5f;

	 void LateUpdate()
	{
		if(playerRoot == null||planeModel == null)
		{
			return;
		}

		Vector3 targetPos = 
			playerRoot.position + planeModel.rotation *offset;
		transform.position = Vector3.Lerp(
			transform.position ,targetPos,
			Time.deltaTime*positionSmooth
			);
		Quaternion targetRot = Quaternion.LookRotation(
			planeModel.forward,
			Vector3.up);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			targetRot,
			Time.deltaTime * rotationSmooth);

	}
}
