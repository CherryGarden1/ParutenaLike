using UnityEngine;

public class EnemyFormationManager : MonoBehaviour
{
    public GameObject enemyPrefab; //“GƒvƒŒƒnƒu
    public int formationRows = 2;@//c‚Ì”@
	public int formationCols = 3;  // ‰¡‚Ì”
	public float spacing = 5f;     // “GŠÔ‚Ì‹——£
	public float moveSpeed = 10f;  // ‘Oi‘¬“x
	public float waveAmplitude = 2f;  // —h‚ê‚Ì•
	public float waveFrequency = 2f;  // —h‚ê‚Ì‘¬‚³

	private Vector3[,] formationOffsets;
	private float waveTimer;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        CreateFormation();
    }

    // Update is called once per frame
    void Update()
    {
        MoveFormation();
    }

    void CreateFormation()
    {
		formationOffsets = new Vector3[formationRows,formationCols];

        for(int row = 0; row < formationRows;row++)
        {
			for (int col = 0; col < formationCols; col++)
			{
				// ‰¡‚Æc‚ÌŠÔŠu‚ğİ’è
				Vector3 offset = new Vector3(
					(col - (formationCols - 1) / 2f) * spacing,
					(row - (formationRows - 1) / 2f) * spacing,
					0f
				);

				formationOffsets[row, col] = offset;

				// “G¶¬
				GameObject enemy = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity, transform);
				enemy.name = $"Enemy_{row}_{col}";
			}
		}
    }

	void MoveFormation()
	{
		// ‘Oi
		transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

		// Œy‚¢ã‰º‚Ì”g‰^“®‚ğ’Ç‰Á
		waveTimer += Time.deltaTime * waveFrequency;
		float wave = Mathf.Sin(waveTimer) * waveAmplitude;

		transform.position += Vector3.up * wave * Time.deltaTime;
	}
}
