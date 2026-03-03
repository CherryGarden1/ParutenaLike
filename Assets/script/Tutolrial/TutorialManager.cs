using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[Header("UI")]
	[SerializeField] TutorialUIManager ui;

	[Header("Step Order (ステージごとにここを変更)")]
	[SerializeField] TutorialStep[] steps;

	[Header("Enemy Destroy Settings")]
	[SerializeField] int requiredDestroyCount = 3;

	[Header("Invisible Count")]
	[SerializeField]int invisibleUseCount = 0;

	[Header("Optional Objects")]
	[SerializeField] GameObject invincibleBoxPrefab;

	public event Action<TutorialStep> OnStepChanged;

	TutorialStep currentStep;
	int currentIndex = 0;
	int destroyCount = 0;

	GameObject invincibleBox;
	PlayerCore player;

	void Awake()
	{
		
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		player = FindFirstObjectByType<PlayerCore>();
	}

	void Start()
	{
		//player = FindFirstObjectByType<PlayerCore>();
		if (steps.Length > 0)
		{
			StartStep(steps[currentIndex]);
		}
	}

	void OnInvisibleUsed()
	{
		if (currentStep != TutorialStep.PlaneZInvincible)
			return;

		invisibleUseCount++;

		if (invisibleUseCount >= 2)
			CompleteCurrentStep();
	}

	void OnEnable()
	{
		Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
		if (player != null)
			player.OnInvisibleUsed += OnInvisibleUsed;
	}

	void OnDisable()
	{
		Enemy.OnEnemyDestroyed -= OnEnemyDestroyed;
		if (player != null)
			player.OnInvisibleUsed -= OnInvisibleUsed;
	}



	void StartStep(TutorialStep step)
	{
		currentStep = step;
		destroyCount = 0;

		OnStepChanged?.Invoke(step);   // UI更新

		switch (step)
		{
			case TutorialStep.PlaneZInvincible:
				SpawnInvincibleBox();
				break;

			case TutorialStep.Complete:
				Cleanup();
				//ui.Hide();
				break;
		}
	}

	public void CompleteCurrentStep()
	{
		currentIndex++;

		if (currentIndex >= steps.Length)
		{
			StartStep(TutorialStep.Complete);
		}
		else
		{
			StartStep(steps[currentIndex]);
		}
	}

	void OnEnemyDestroyed()
	{
		Debug.Log("Kimasita");
		// 撃破判定を使うステップだけ反応
		if (currentStep != TutorialStep.NormalShot &&
			currentStep != TutorialStep.TransformChain)
			return;

		destroyCount++;

		if (destroyCount >= requiredDestroyCount)
		{
			CompleteCurrentStep();
		}
	}

	void SpawnInvincibleBox()
	{
		if (invincibleBox != null || invincibleBoxPrefab == null)
			return;

		invincibleBox = Instantiate(invincibleBoxPrefab);
	}

	void Cleanup()
	{
		if (invincibleBox != null)
			Destroy(invincibleBox);
	}
}
