using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ScloolTest : MonoBehaviour
{
	[SerializeField] private GameObject scrollBlockObject;//素材指定
	[SerializeField] private Transform blockPopPoint;//生成位置
	[SerializeField] private Vector3 blockMoveForward = new Vector3(0, 0, 1);//並ぶ方向
	[SerializeField] private int before_block_create_count = 2;//最初の数
	[SerializeField] private Vector3 playerOffset;


	private Renderer beforeBlockRender;

	void Start()
	{
		// 最初に並べる
		if (scrollBlockObject != null && before_block_create_count > 0)
		{
			//素材の大きさを取得
			Renderer prefabRenderer = scrollBlockObject.GetComponent<Renderer>();
			Vector3 blockSize = prefabRenderer.bounds.size;

			Vector3 createPosition = blockPopPoint.position + playerOffset;
			//before_block_create_count個ブロックを並べてblockPopPointを基準に配置
			for (int i = 0; i < before_block_create_count; i++)
			{
				if (i == 0)
				{
					// 最初の1個 → プレイヤーの真下
					Vector3 firstPos = blockPopPoint.position　+playerOffset;
					CreateBlock(firstPos);
				}
				else
				{
					//2個目以降は直前のブロックのサイズ分先方に並べる
					Bounds lastBounds = beforeBlockRender.bounds;
					Vector3 nextPosition = lastBounds.center + blockMoveForward.normalized * lastBounds.size.z;
					CreateBlock(createPosition);
				}
				
			}
		}
	}

	private void Update()
	{
		//ブロックがなければ何もしない
		if (beforeBlockRender == null) return;

		// 最後に生成したブロックのBoundsを取得
		Bounds lastBounds = beforeBlockRender.bounds;

		// 次のブロックの生成位置（Z方向に一つ分進める）
		Vector3 nextPosition = lastBounds.center + blockMoveForward.normalized * lastBounds.size.z;

		// blockPopPoint が最後のブロックの中にいない → 追加生成
		if (!lastBounds.Contains(blockPopPoint.position))
		{
		
		}
	}

	private void CreateBlock(Vector3 createPosition)
	{
		GameObject blockObject = Instantiate(scrollBlockObject, createPosition, scrollBlockObject.transform.rotation);

		// 移動と削除を行うコンポーネント
		blockObject.AddComponent<AutoDestroy>().time = 30f; // 少し長め
		//blockObject.AddComponent<ObjectTransform>().translate = blockMoveForward;
		blockObject.transform.Translate(blockMoveForward, Space.World);
		beforeBlockRender = blockObject.GetComponent<Renderer>();
		blockObject.GetComponentInChildren<StageEnd>().NextStage += OnNextStage;
	}

	private void OnNextStage()
	{
		Debug.Log("NextStage");
		// 最後に生成したブロックのBoundsを取得
		Bounds lastBounds = beforeBlockRender.bounds;

		// 次のブロックの生成位置（Z方向に一つ分進める）
		Vector3 nextPosition = lastBounds.center + blockMoveForward.normalized * lastBounds.size.z;

		CreateBlock(nextPosition);

	}
}

