using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
	[Header("Reference")]
	[SerializeField] private PlayerCore player;
	[SerializeField] private Image hpFill;
	[SerializeField]private Image abilityFill;
	[SerializeField] private TMP_Text lifeText;
	[SerializeField]private TMP_Text scoreText;
	[SerializeField] private RectTransform crosshairUI;

	void Start()
	{
		player.OnAbilityGaugeChanged += UpdateAbility;
		if(player == null)
		{
			Debug.LogError("PlayerCore is not assigned to PlayerHUD");
			return;

		}
		// èâä˙îΩâf
		UpdateHP(player.currentHP, player.maxHP);
		UpdateBomb(player.bombGauge);
		UpdateLife(player.life);
		UpdateScore(player.score);

		// ÉCÉxÉìÉgìoò^
		player.OnHPChanged += UpdateHP;
		//player.OnBombChanged += UpdateBomb;
		player.OnLifeChanged += UpdateLife;
		player.OnScoreChanged += UpdateScore;
	}

	void OnDestroy()
	{
		if (player == null) return;

		player.OnHPChanged -= UpdateHP;
		//player.OnBombChanged -= UpdateBomb;
		player.OnLifeChanged -= UpdateLife;
		player.OnScoreChanged -= UpdateScore;
	}

	void UpdateHP(int current, int max)
	{
		hpFill.fillAmount = (float)current / max;
	}
	void UpdateBomb(float value)
	{
		abilityFill.fillAmount = value / player.abilityMax;
	}

	void UpdateLife(int life)
	{
		lifeText.text = $"x {life}";
	}

	void UpdateScore(int score)
	{
		scoreText.text = score.ToString();
	}
	void UpdateAbility(float current, float max)
	{
		abilityFill.fillAmount = current / max;
	}
}
