using UnityEngine;
//ワールド全体をスクロール
public class WolrdScrollManager : MonoBehaviour
{
	public static WolrdScrollManager Instance;
	public float scrollSpeed = 20f;

	//最初に呼ばれる
	void Awake()
	{
		//自信をス他ティック変数に代入
		Instance = this;
	}

	//指定したtransformをスクロールさせる
	//引数ｔ　：動かしたいオブジェクトのtransfom
	public void ApplySclooll(Transform t)
	{
		t.position += Vector3.forward * scrollSpeed * Time.deltaTime;
	}
}
