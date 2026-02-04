using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
	[SerializeField] TutorialManager tutorialManager;
	[SerializeField] TutorialMessageUI messageUI;
	[SerializeField] TutorialHighlightUI highlightUI;
	[SerializeField] TutorialArrowUI arrowUI;

	void Start()
	{
		UpdateUI(tutorialManager.CompleteCurrentStep);
		tutorialManager.OnStepChanged += UpdateUI;
	}

	void OnDestroy()
	{
		tutorialManager.OnStepChanged -= UpdateUI;
	}

	void UpdateUI(TutorialStep step)
	{
		messageUI.Show(step);
		highlightUI.Show(step);
		arrowUI.Show(step);
	}
}
