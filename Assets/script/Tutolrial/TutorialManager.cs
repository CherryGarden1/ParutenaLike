using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[Header("UI")]
	[SerializeField] TutorialUI ui;

	[Header("Step Order (ステージごとにここを変更)")]
	[SerializeField] TutorialStep[] steps;

	[Header("Enemy Destroy Settings")]
	[SerializeField] int requiredDestroyCount = 3;

	[Header("Optional Objects")]
	[SerializeField] GameObject invincibleBoxPrefab;

	public event Action<TutorialStep> OnStepChanged;

	TutorialStep currentStep;
	int currentIndex = 0;
	int destroyCount = 0;

	GameObject invincibleBox;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	void OnEnable()
	{
		Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
	}

	void OnDisable()
	{
		Enemy.OnEnemyDestroyed -= OnEnemyDestroyed;
	}

	void Start()
	{
		if (steps.Length == 0)
		{
			Debug.LogWarning("Tutorial steps not set.");
			return;
		}

		StartStep(steps[currentIndex]);
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
				ui.Hide();
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
