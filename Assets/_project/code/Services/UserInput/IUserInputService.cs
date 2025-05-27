﻿using System;
using Services.Updater;
using UnityEngine;

namespace Services.UserInput
{
	public interface IUserInputService : ITick
	{
		event Action<Vector2> onMouseButtonLeftDown;
		event Action<Vector2> onMouseButtonLeft;
		event Action<Vector2> onMouseButtonLeftUp;
		event Action<Vector2> onMouseButtonRightDown;
		event Action<Vector2> onMouseButtonRight;
		event Action<Vector2> onMouseButtonRightUp;
		event Action onSaveGame;
		event Action onTryInteract;
		event Action onWalkToggled;
		event Action onSprintActivated;
		event Action onSprintDeactivated;
		event Action onCrouchActivated;
		event Action onCrouchDeactivated;
		event Action onJumpPerformed;
		
		bool MovementInputDetected { get; }
		float MovementInputDuration { set; get; }
		Vector2 MoveComposite { get; }
		float HorizontalMouseAxis { get; }
		float GetMouseScrollWheel { get; }
		Vector2 MousePosition { get; }
	}
}