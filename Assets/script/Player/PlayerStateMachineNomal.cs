using UnityEngine;

public class PlayerStateMachineNormal : PlayerStateMachineBase
{
	[SerializeField] PlayerMove move;

	protected override void HandleStateInput()
	{
		Vector2 input = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);

		move.HandleInput(input);
	}
}
