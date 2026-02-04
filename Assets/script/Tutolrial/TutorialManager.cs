using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[SerializeField] TutorialUI ui;
	[SerializeField] GameObject invincibleBoxPrefab;
	TutorialStep current;
	GameObject invincibleBox;
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject );
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
				ui.Show("“G‚ðŒ‚”j‚µ‚æ‚¤");
				break;

			case TutorialStep.PlaneZInvincible:
				ui.Show("ZƒL[‚Å–³“G‚ðŽg‚¨‚¤");
				SpawnInvincibleBox();
				break;

			case TutorialStep.TransformChain:
				ui.Show("•ÏŒ`‚µ‚ÄZƒL[‚Åˆê‘|‚µ‚æ‚¤");
				break;

			case TutorialStep.Complete:
				ui.Hide();
				break;
		}
	}
	public void CompleteCurrentStep()
	{
		TutorialStep next = current + 1;
		if(next >= TutorialStep.Complete)
		{
			StartStep(TutorialStep.Complete);
		}
		else
		{
			StartStep(next);
		}
	}

	void SpawnInvincibleBox()
	{
		if(invincibleBox != null)return;
		invincibleBox = Instantiate(invincibleBoxPrefab);

	}
	void CleaInvicibleBox()
	{
		if (invincibleBox)
			Destroy(invincibleBox);
	}
}
