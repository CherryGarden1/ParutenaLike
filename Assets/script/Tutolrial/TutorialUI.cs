using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TutorialUI : MonoBehaviour
{
	//Œ©‚½–Ú‚Ì‚Ý
	[SerializeField] CanvasGroup root;
	[SerializeField] Text messageText;

	public void Show(string message)
	{
		messageText.text = message;
		root.alpha = 1f;
		root.blocksRaycasts = true;
		root.interactable = true;
	}

	public void Hide()
	{
		root.alpha = 0f;
		root.blocksRaycasts = false;
		root.interactable = false;
	}
}
