using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStateMachine : MonoBehaviour
{
	[SerializeField] PlayerCore core;
	[SerializeField] BossPlaneMove planeMove;
	[SerializeField] BossHumanMove humanMove;
	[SerializeField] GameObject planeObject; // PlaneFormBoss
	[SerializeField] GameObject humanObject; // HumanForm_Boss
	[SerializeField] BossCameraPlaneFollow planeCamera;
	[SerializeField] BossHumanCamera humanCamera;
	public PlayerState CurrentState { get; private set; }

	void Awake()
	{
		if (core == null)
			core = GetComponent<PlayerCore>();
		if (core == null)
			core = GetComponentInParent<PlayerCore>();

		//if (core == null)
		//	Debug.LogError($"{name}: PlayerCore not found");
	}

	void Start()
	{
		SwitchState(PlayerState.Plane);
	}

	void Update()
	{
		//Debug.Log("Update running");
		//Debug.Log("CurrentState = " + CurrentState);
		HandleInput();
	}

	void HandleInput()
	{
		// 変形中は入力を一切受けない
		if (CurrentState == PlayerState.Transforming)
			return;

		// 形態切替
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			StartTransform();
			Debug.Log("LeftShift");
			return;
		}

		// 各形態固有入力
		switch (CurrentState)
		{
			case PlayerState.Plane:
				planeMove.HandleInput();
				break;

			case PlayerState.Human:
				humanMove.HandleInput();
				break;
		}
	}

	// ===== 状態遷移 =====

	void StartTransform()
	{
		Debug.Log("StartTransform");
		SwitchState(PlayerState.Transforming);

		// 見た目切替
		core.ToggleForm();

		// アニメが無い仮実装（0.3秒後に完了）
		//Invoke(nameof(FinishTransform), 0.3f);
	}

	public void FinishTransform()
	{
		Debug.Log("FinishTransform called from Core");
		SwitchState(
			core.CurrentForm == PlayerForm.Plane
			? PlayerState.Plane
			: PlayerState.Human
		);
	}

	void SwitchState(PlayerState next)
	{
		CurrentState = next;

		// 1. まずオブジェクト自体のActiveを切り替える
		if (planeObject != null) planeObject.SetActive(next == PlayerState.Plane);
		if (humanObject != null) humanObject.SetActive(next == PlayerState.Human);

		// 2. その上でスクリプトの有効化（ここは今のままでもOK）
		planeMove.enabled = (next == PlayerState.Plane);
		humanMove.enabled = (next == PlayerState.Human);

		planeCamera.enabled = (next == PlayerState.Plane);
		humanCamera.enabled = (next == PlayerState.Human);

		Debug.Log($"Object Switched: Plane={planeObject.activeSelf}, Human={humanObject.activeSelf}");
	}
}
