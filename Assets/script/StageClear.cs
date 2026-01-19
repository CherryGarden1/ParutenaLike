using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
	public void GoToBoss()
	{
		SceneManager.LoadScene("BossScene");
	}
}
