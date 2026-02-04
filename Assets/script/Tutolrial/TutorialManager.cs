using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[SerializeField] TutorialUI ui;
	[SerializeField] GameObject invincibleBoxPrefab;
	TutorialStep current;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}

	void Start()
	{
		StartStep(TutorialStep.NormalShot);
	}
	void StartStep(TutorialStep step)
	{
		current = step;

		switch (step)
		{
			case TutorialStep.NormalShot:
				ui.Show("ìGÇåÇîjÇµÇÊÇ§");
				break;

			case TutorialStep.PlaneZInvincible:
				ui.Show("ZÉLÅ[Ç≈ñ≥ìGÇégÇ®Ç§");
				SpawnInvincibleBox();
				break;

			case TutorialStep.TransformChain:
				ui.Show("ïœå`ÇµÇƒZÉLÅ[Ç≈àÍë|ÇµÇÊÇ§");
				break;

			case TutorialStep.Complete:
				ui.Hide();
				break;
		}
	}
	public void CompleteCurrentStep()
	{
		switch (current)
		{
			case TutorialStep.NormalShot:
				StartStep(TutorialStep.PlaneZInvincible);
				break;

			case TutorialStep.PlaneZInvincible:
				StartStep(TutorialStep.TransformChain);
				break;

			case TutorialStep.TransformChain:
				StartStep(TutorialStep.Complete);
				break;
		}
	}

	void SpawnInvincibleBox()
	{
		Instantiate(invincibleBoxPrefab);

	}
}
