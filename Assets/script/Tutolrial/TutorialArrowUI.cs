
using UnityEngine;

public class TutorialArrowUI : MonoBehaviour
{
	[SerializeField] GameObject zKeyIcon;
	[SerializeField] GameObject shiftKeyIcon;

	public void Show(TutorialStep step)
	{
		zKeyIcon.SetActive(false);
		shiftKeyIcon.SetActive(false);

		switch (step)
		{
			case TutorialStep.PlaneZInvincible:
				zKeyIcon.SetActive(true);
				break;

			case TutorialStep.TransformChain:
				zKeyIcon.SetActive(true);
				shiftKeyIcon.SetActive(true);
				break;
		}
	}
}