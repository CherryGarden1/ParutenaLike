using UnityEngine;

public class TutorialHighlightUI : MonoBehaviour
{
	[SerializeField] GameObject invincibleArea;

	public void Show(TutorialStep step)
	{
		invincibleArea.SetActive(step == TutorialStep.PlaneZInvincible);
	}
}

