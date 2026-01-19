using System;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
	//ヒットポイント
	[Header("HP")]
	public int maxHP = 100;
	public int currentHP;
	//残機
	[Header("Life")]
	public int life = 3;
	//ボム
	[Header("Bomb")]
	public float bombGauge = 0f;
	public float bombMax = 100f;
	//無敵
	[Header("Invincible")]
	public bool isInvincible = false;
	private float invincibleTimer;
	//スコア
	[Header("Score")]
	public int score = 0;
	//クロスヘア
	[Header("HUD")]
	[SerializeField] private CrossHair crossHair;
	public CrossHair CrossHair => crossHair;
	[Header("Forms")]
	[SerializeField] private GameObject planeForm;
	[SerializeField] private GameObject humanForm;

	public enum PlayerForm
	{
		Plane,
		Human
			
	}

	public PlayerForm CurrentForm { get; private set; } = PlayerForm.Plane;
	// ===== イベント =====
	public event Action<int, int> OnHPChanged;
	public event Action<int> OnLifeChanged;
	public event Action<float> OnBombChanged;
	public event Action<int> OnScoreChanged;
	public event Action OnPlayerDead;
	public event Action<PlayerForm> OnFormChanged;

	void Start()
	{
		SwitchForm(PlayerForm.Plane);
	}

	void Awake()
	{
		currentHP = maxHP;
	}

	void Update()
	{
		// 無敵時間の管理
		if (isInvincible)
		{
			invincibleTimer -= Time.deltaTime;
			if (invincibleTimer <= 0f)
			{
				isInvincible = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			ToggleForm();
		}
	}

	// ===== HP =====
	public void TakeDamage(int damage)
	{
		if (isInvincible) return;

		currentHP -= damage;
		currentHP = Mathf.Max(currentHP, 0);

		OnHPChanged?.Invoke(currentHP, maxHP);

		if (currentHP <= 0)
		{
			Die();
		}
	}

	public void Heal(int value)
	{
		currentHP = Mathf.Min(currentHP + value, maxHP);
		OnHPChanged?.Invoke(currentHP, maxHP);
	}

	// ===== 無敵 =====
	public void SetInvincible(float time)
	{
		isInvincible = true;
		invincibleTimer = time;
	}

	// ===== ボム =====
	public bool ConsumeBomb(float value)
	{
		if (bombGauge < value) return false;

		bombGauge -= value;
		OnBombChanged?.Invoke(bombGauge);
		return true;
	}

	public void AddBomb(float value)
	{
		bombGauge = Mathf.Min(bombGauge + value, bombMax);
		OnBombChanged?.Invoke(bombGauge);
	}

	// ===== スコア =====
	public void AddScore(int value)
	{
		score += value;
		OnScoreChanged?.Invoke(score);

		// 残機増加（例：100000点ごと）
		if (score % 100000 == 0)
		{
			AddLife(1);
		}
	}

	// ===== 残機 =====
	void AddLife(int value)
	{
		life += value;
		OnLifeChanged?.Invoke(life);
	}

	void Die()
	{
		life--;
		OnLifeChanged?.Invoke(life);

		if (life < 0)
		{
			OnPlayerDead?.Invoke();
			Debug.Log("Game Over");
		}
		else
		{
			Respawn();
		}
	}

	void Respawn()
	{
		currentHP = maxHP;
		SetInvincible(2f);
		OnHPChanged?.Invoke(currentHP, maxHP);
	}
	//
	public void ToggleForm()
	{
		if (CurrentForm == PlayerForm.Plane)
			SwitchForm(PlayerForm.Human);
		else
			SwitchForm(PlayerForm.Plane);
	}
	//
	void SwitchForm(PlayerForm from)
	{
		CurrentForm = from;

		planeForm.SetActive(from == PlayerForm.Plane);
		humanForm.SetActive(from == PlayerForm.Human);

		OnFormChanged?.Invoke(from);
	}
}
