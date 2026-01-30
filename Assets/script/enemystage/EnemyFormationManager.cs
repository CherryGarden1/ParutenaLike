using UnityEngine;

public class EnemyFormationManager : MonoBehaviour
{
	EnemyFomationData data;
	float waveTimer;

public void Init(EnemyFomationData fomationData)
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

        for(int r = 0; row < data.rows;r++)
        {
			for (int c = 0; c < data.cols; c++)
			{
				// ‰¡‚Æc‚ÌŠÔŠu‚ðÝ’è
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
		// ‘Oi
		transform.position += Vector3.forward * data.moveSpeed * Time.deltaTime;

		// Œy‚¢ã‰º‚Ì”g‰^“®‚ð’Ç‰Á
		waveTimer += Time.deltaTime * data.waveFrequency;
		float wave = Mathf.Sin(waveTimer) * data.waveAmplitude;

		transform.position += Vector3.up * wave * Time.deltaTime;
	}
}
