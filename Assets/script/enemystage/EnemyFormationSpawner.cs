using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationSpawner : MonoBehaviour
{
	[SerializeField] EnemyFormationManager formationPrefab;
	[SerializeField] EnemyFomationData[] fomationList;

	List<EnemyFomationData> unusedFomations;

	 void Awake()
	{
		unusedFomations = new List<EnemyFomationData>(fomationList);

	}
	public void SpawnNext(Vector3 position)
	{
		if(unusedFomations.Count == 0)
		{
			Debug.Log("All used");
			return;
		}
		int index = Random.Range(0,unusedFomations.Count);
		EnemyFomationData data = unusedFomations[index];
		unusedFomations.RemoveAt(index);

		EnemyFormationManager fomation =
			Instantiate(formationPrefab, position, Quaternion. identity);

		fomation.Init(data);
	}
}
