using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	
	[SerializeField]
	private GameObject[] EnemyPrefabs;//素材指定
	[SerializeField]
	private float SpawnDistanse = 10f;//前方距離
	[SerializeField]
	private float SpawnHeight = 5f;//上から降ってくる高さ

	public event System.Action Generate;

	private static int currentIndex = 0; // どの敵を出すか管理

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Trigger entered by: {other.name}");
		Transform Player = GameObject.Find("playerTest").transform;
		if (other.CompareTag("Player"))
		{


	
			Debug.Log("Player detected"); 
			//プレイヤーの前方、上に生成
			Vector3 SpawnPos = Player.position + Vector3.forward * SpawnDistanse;
			SpawnPos.y += SpawnHeight;

		GenerateEnemy(SpawnPos);
		}
		Generate?.Invoke();


	}


	private void GenerateEnemy(Vector3 CreatePosition)
	{
		if (EnemyPrefabs.Length == 0) return;
		GameObject Prefab = EnemyPrefabs[currentIndex];

		Instantiate(Prefab, CreatePosition, Quaternion.identity);

		// 次の敵に進める（最後までいったら最初に戻る）
		currentIndex = (currentIndex + 1) % EnemyPrefabs.Length;
		Debug.Log($"Spawned enemy #{currentIndex}");
	}
}
