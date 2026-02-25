using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
	public PlayerCore player;

	public Slider hpSlider;
	public Slider blastSlider;
	public Slider invincibleSlider;

	void Start()
	{
		player.OnHPChanged += UpdateHP;
		player.OnBlastChargeChanged += UpdateBlast;
		player.OnInvincibleChargeChanged += UpdateInvincible;

		UpdateHP(player.currentHP, player.maxHP);
		UpdateBlast(player.blastCharge, player.blastMax);
		UpdateInvincible(player.invincibleCharge, player.invincibleMax);
	}

	void UpdateHP(int current, int max)
	{
		hpSlider.value = (float)current / max;
	}

	void UpdateBlast(float current, float max)
	{
		blastSlider.value = current / max;
	}

	void UpdateInvincible(float current, float max)
	{
		invincibleSlider.value = current / max;
	}
}
