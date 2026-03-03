using UnityEngine;

[DefaultExecutionOrder(-100)]
public class TutorialUIManager : MonoBehaviour
{
	[SerializeField] TutorialManager tutorialManager;
	[SerializeField] TutorialMessageUI messageUI;
	[SerializeField] TutorialHighlightUI highlightUI;
	[SerializeField] TutorialArrowUI arrowUI;

	void Start()
	{
		tutorialManager.OnStepChanged += UpdateUI;
	}

	void OnDestroy()
	{
		tutorialManager.OnStepChanged -= UpdateUI;
	}

	void UpdateUI(TutorialStep step)
	{
		//ステップ終わったら終了
		if (step == TutorialStep.Complete)
		{
			gameObject.SetActive(false);
			return;
		}

		messageUI.Show(step);
		highlightUI.Show(step);
		arrowUI.Show(step);
	}

}
