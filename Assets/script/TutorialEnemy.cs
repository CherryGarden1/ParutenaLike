using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
	public float fallSpeed = 5f; // 落下スピード
								 //public float moveSpeed = 3f; // プレイヤー追跡スピード
	public float frontOffset = 20; //追跡する位置（プレイヤーの前方）
	public float radius = 10f; //半径
	public float rotateSpeed = 2f; //角速度
	public Transform player;

	private bool hasLanded = false;
	private Vector3 offset;
	private Transform target;
	private Vector3 circleCenter; //回転の中心
	private float angle = 0f;
	private Transform cam;

	private void Start()
	{
		// シーン上のプレイヤーを自動で取得
		player = GameObject.Find("playerTest").transform;
		cam = Camera.main?.transform;

		if (player != null)
		{
			// プレイヤーの前方位置を計算
			offset = player.forward * frontOffset;
		}
		else
		{
			Debug.LogError("Player not found in scene!");
		}

	}

	private void Update()
	{
		if (player == null) return;
		if (!hasLanded)
		{
			// 下に移動
			transform.position += Vector3.down * fallSpeed * Time.deltaTime;

			//メインカメラのY軸を取得
			float cameraY = Camera.main.transform.position.y;
			// プレイヤーの目の前に来たら
			if (transform.position.y <= cameraY) // ← 地面の高さに合わせる
			{
				hasLanded = true;

				angle = Random.Range(0f, Mathf.PI * 2f);
				Debug.Log("Start Circle Motion");
			}

		}
		else
		{
			//カメラを中心に円運動
			angle += rotateSpeed * Time.deltaTime;

			//座標計算
			Vector3 circlePos = cam.position
			+ cam.forward * frontOffset //カメラの前方
			+ cam.right * Mathf.Cos(angle) * radius //水平方向
			+ cam.up * Mathf.Sin(angle) * radius; //垂直方向

			transform.position = circlePos;
			//プレイヤーの方向を向く
			transform.LookAt(player);


		}
	}
}
