using UnityEngine;

public class PlayerStateMachineBoss : PlayerStateMachineBase
{

   //
	protected override void HandleStateInput()
	{
		switch (state)
		{
			case PlayerState.Plane:
				planeMove.HandleInput();
				break;

			case PlayerState.Human:
			    humanMove.HandleInput();
				break;
		}
	}
}

