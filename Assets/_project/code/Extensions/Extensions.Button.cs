﻿using System;
using UnityEngine.UI;

namespace Extensions
{
	public static partial class Extensions
	{
		public static void Enable(this Button button) => button.enabled = true;
		public static void Disable(this Button button) => button.enabled = false;
		public static void Activate(this Button button) => button.interactable = true;
		public static void Deactivate(this Button button) => button.interactable = false;

		public static void AddOneListener(this Button button, Action action)
		{
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(() => action?.Invoke());
		}

		public static void AddListener(this Button button, Action action)
		{
			button.onClick.AddListener(() => action?.Invoke());
		}
	}
}