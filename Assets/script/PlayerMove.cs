using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	//左右移動速度の設定
	[SerializeField]
	private float speed;
	[SerializeField]
	private float scrollSpeed;
	//最後にいた位置
	public　Vector3 lastPosition;
	//他で引っ張るよう
	public Vector3 currentVelocity { get; private set; }
	//リジットボディの確認
	Rigidbody rb;
	//アニメーションのコンポーネントの確認
	//Animator animator;
	private void Start()
	{
		rb = GetComponent<Rigidbody>();

		// Rigidbody の補正（物理で転がらないように）
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FixedUpdate()
	{

		// 入力取得（WASD / 矢印キー）
		float x = Input.GetAxis("Horizontal"); // A(-1) D(+1)
		float y = Input.GetAxis("Vertical");     // ワールド座標XZ平面での移動ベクトル
		Vector3 input = new Vector3(x, y, 0).normalized;
		Vector3 movement = new Vector3(input.x * speed, input.y * speed, scrollSpeed);
		//動いてるか確認
		bool Run = y!=0 || x!=0;
		// 移動適用
		rb.MovePosition(rb.position + movement * Time.deltaTime);

		// 現在の速度ベクトルを計算
		currentVelocity = (transform.position - lastPosition) / Time.deltaTime;
		lastPosition = transform.position;
	}
}
