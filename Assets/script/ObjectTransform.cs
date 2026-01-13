using UnityEngine;

public class ObjectTransform : MonoBehaviour
{
	//スクロールのスピード
	public Vector3 translate;

	void Update()
	{
		//ワールド座標基準で移動
		if (translate != Vector3.zero)
		{
			transform.Translate(translate, Space.World);
		}
	}
}
