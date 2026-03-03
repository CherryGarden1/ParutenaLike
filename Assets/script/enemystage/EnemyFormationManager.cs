using UnityEngine;
using static EnemyFormationData;

public class EnemyFormationManager : MonoBehaviour
{
	//プレハブに付ける！
	

	EnemyFormationData data;
	float waveTimer;

public void Init(EnemyFormationData fomationData)
	{
		data = fomationData;
		CreateFormation();
	}

    // Update is called once per frame
    void Update()
    {
		if(data == null)return;
        MoveFormation();
    }
	void CreateFormation()
	{
		switch (data.formationType)
		{
			case FormationType.Grid:
				CreateGrid();
				break;

			//case FormationType.Circle:
			//	CreateCircle();
			//	break;

			case FormationType.VShape:
				CreateVShape();
				break;
		}
	}
	void CreateGrid()
    {

        for(int r = 0; r < data.rows;r++)
        {
			for (int c = 0; c < data.cols; c++)
			{
				// 横と縦の間隔を設定
				Vector3 offset = new Vector3(
					(c - (data.cols - 1) / 2f) * data.spacing,
					(r - (data.rows - 1) / 2f) * data.spacing,
					0f
				);
				Instantiate(
					data.enemyPrefab,
					transform.position + offset,
					Quaternion.identity,
					transform
					);

			}
		}
    }

	void MoveFormation()
	{
		// 前進
		transform.position += Vector3.forward * data.moveSpeed * Time.deltaTime;

		// 軽い上下の波運動を追加
		waveTimer += Time.deltaTime * data.waveFrequency;
		float wave = Mathf.Sin(waveTimer) * data.waveAmplitude;

		transform.position += Vector3.up * wave * Time.deltaTime;
	}
	void CreateVShape()
	{
		int count = data.cols;   // 横の数を使用

		for (int i = 0; i < count; i++)
		{
			float centerOffset = i - (count - 1) / 2f;

			float x = centerOffset * data.spacing;
			float y = -Mathf.Abs(centerOffset) * data.spacing * 0.5f;

			Instantiate(
				data.enemyPrefab,
				transform.position + new Vector3(x, y, 0f),
				Quaternion.identity,
				transform
			);
		}
	}
}
