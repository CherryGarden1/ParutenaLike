using UnityEngine;
using System.Collections;

public abstract class PlayerStateMachineBase : MonoBehaviour
{
	[SerializeField] protected PlayerCore core;

	[Header("Plane")]
	[SerializeField] protected BossPlaneMove planeMove;
	[SerializeField] protected MonoBehaviour planeCamera;

	[Header("Human")]
	[SerializeField] protected BossHumanMove humanMove;
	[SerializeField] protected MonoBehaviour humanCamera;

	protected PlayerState state;

	protected virtual void Awake()
	{
		if (!core)
			core = GetComponent<PlayerCore>();
	}

	protected virtual void Start()
	{
		SwitchState(PlayerState.Plane);
	}

	protected virtual void Update()
	{
		if (state == PlayerState.Transforming)
			return;

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			StartCoroutine(TransformRoutine());
			return;
		}

		HandleStateInput();
	}

	protected abstract void HandleStateInput();

	// ===== •ÏŒ` =====
	protected IEnumerator TransformRoutine()
	{
		SwitchState(PlayerState.Transforming);

		yield return new WaitForSeconds(0.3f);

		PlayerForm next =
			core.CurrentForm == PlayerForm.Plane
			? PlayerForm.Human
			: PlayerForm.Plane;

		core.SetForm(next);

		SwitchState(
			next == PlayerForm.Plane
			? PlayerState.Plane
			: PlayerState.Human
		);
	}

	protected void SwitchState(PlayerState next)
	{
		state = next;

		bool isPlane = next == PlayerState.Plane;
		bool isHuman = next == PlayerState.Human;

		if (planeMove) planeMove.enabled = isPlane;
		if (planeCamera) planeCamera.enabled = isPlane;

		if (humanMove) humanMove.enabled = isHuman;
		if (humanCamera) humanCamera.enabled = isHuman;
	}
}

