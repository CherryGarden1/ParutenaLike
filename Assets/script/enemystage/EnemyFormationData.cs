using UnityEngine;
[CreateAssetMenu(
	fileName =	"WnwmyFomationData",
	menuName ="Enemy/Formation Data"
	)]
public class EnemyFormationData: ScriptableObject
{
	[Header("Formation Shape")]
	public int rows = 2;
	public int cols = 3;
	public float spacing = 5f;

	[Header("Enemy")]
	public GameObject enemyPrefab;

	[Header("Movement")]
	public float moveSpeed = 10f;
	public float waveAmplitude = 2f;
	public float waveFrequency = 2f;
}
