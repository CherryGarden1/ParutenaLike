using UnityEngine;

public class TestEnemy : MonoBehaviour
{
	public float fallSpeed = 5f; // 落下スピード
	public float moveSpeed = 3f; // プレイヤー追跡スピード
	public float frontOffset = 20; //追跡する位置（プレイヤーの前方）
	private bool hasLanded = false;

	private Transform target;

	private void Start()
	{
		target = GameObject.Find("playerTest").transform;
	}
	private void Update()
	{
		Transform target = GameObject.Find("playerTest").transform;
		if (!hasLanded)
		{
			// 下に移動
			transform.position += Vector3.down * fallSpeed * Time.deltaTime;

			// 地面に到達したら追跡に切り替え
			if (transform.position.y <= 0.5f) // ← 地面の高さに合わせる
			{
				hasLanded = true;
				Debug.Log("tracking");
			}
	
		}
		else
		{

			// プレイヤーの前方に基づいた目標位置を計算
			Vector3 forwardDir = target.TransformDirection(Vector3.forward); // モデルの前方(Z軸基準)
			Vector3 targetPos = target.position + target.forward * frontOffset;

			// Y軸は敵の高さを維持
			targetPos.y = transform.position.y;

			// 目標位置に向かって移動
			Vector3 direction = (targetPos - transform.position).normalized;
			transform.position += direction * moveSpeed * Time.deltaTime;

			// 向きをプレイヤーの前方に合わせる
			if (direction.sqrMagnitude > 0.001f)
			{
				Quaternion targetRot = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
			}
		}
		
	}
}
