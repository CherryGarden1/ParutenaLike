using TMPro;
using UnityEngine;

public class TutorialMessageUI : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI messageText;

	public void Show(TutorialStep step)
	{
		switch (step)
		{
			case TutorialStep.NormalShot:
				messageText.text = "敵をショットで全滅させよう！";
				break;

			case TutorialStep.PlaneZInvincible:
				messageText.text = "Zキーで特殊攻撃！\n無敵中だ！";
				break;

			case TutorialStep.TransformChain:
				messageText.text = "Shiftで変形！\nZキーで連鎖爆発！";
				break;

			case TutorialStep.Complete:
				messageText.text = "";
				break;
		}

		gameObject.SetActive(step != TutorialStep.Complete);
	}
}
