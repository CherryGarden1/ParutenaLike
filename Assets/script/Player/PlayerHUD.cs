
using UnityEngine;
using UnityEngine.UI;
public class PlayerHud : MonoBehaviour
{
	public Image PowerFill;
	public Image hpFill;
	private PlayerCore player;

	private void Start()
	{
		player = FindFirstObjectByType<PlayerCore>();

		player.OnHPChanged += UpdateHP;
		player.OnAbilityGaugeChanged += UpdateAbility;
	}
	public void UpdateHP(int current, int max)
	{
		float ratio = (float)current / max;
		Debug.Log($"HP: {current}");
		hpFill.fillAmount = ratio;
	}
	public void UpdateAbility(float current, float max)
	{
		PowerFill.fillAmount = current / max;
	}

}
