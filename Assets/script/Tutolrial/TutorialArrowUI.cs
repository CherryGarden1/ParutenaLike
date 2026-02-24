
using UnityEngine;

public class TutorialArrowUI : MonoBehaviour
{
	[SerializeField] GameObject zKeyIcon; //Zキーの画像
	[SerializeField] GameObject shiftKeyIcon; //sihtの画像

	public void Show(TutorialStep step)
	{
		zKeyIcon.SetActive(false);
		shiftKeyIcon.SetActive(false);
		//ステップ
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