using UnityEngine;
[CreateAssetMenu(
	fileName =	"EnemyFomationData",
	menuName ="Enemy/Formation Data"
	)]
public class EnemyFormationData: ScriptableObject
{
	public enum FormationType
	{
		Grid,//Šiq
		VShape,//Vš
		LineHorizontal,//‰¡‚P—ñ
		LineVertical,//|—ñ
		Circle,//‰~Œ`
		XShape,
		ReverseV,
		WShape,
		Random,
		Guard
	}

	[Header("Formation Type")]
	public FormationType formationType = FormationType.Grid;
	[Header("Formation Shape")]
	public int rows = 2;
	public int cols = 3;
	public float spacing = 5f;

	[Header("Enemy")]
	public EnemyBase enemyPrefab;

	[Header("Movement")]
	public float moveSpeed = 10f;
	public float waveAmplitude = 2f;//U•
	public float waveFrequency = 2f;//•p“x
	[Header("Enemy Count Override")]
	public int overrideCount = -1;//”w’è—p-1‚È‚çŒü‚±‚¤

}
