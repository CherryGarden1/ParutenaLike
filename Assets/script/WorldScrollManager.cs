using UnityEngine;
//ワールド全体をスクロール
public class WorldScrollManager : MonoBehaviour
{
	public static WorldScrollManager Instance;
	public float scrollSpeed = 20f;

	//最初に呼ばれる
	void Awake()
	{
		//自信をス他ティック変数に代入
		Instance = this;
		//Debug.Log("WorldScrollManager amake");
	}


	//指定したtransformをスクロールさせる
	//引数ｔ　：動かしたいオブジェクトのtransfom
	 void Update()
	{
		transform.position += Vector3.forward * scrollSpeed * Time.deltaTime;
	}
}
