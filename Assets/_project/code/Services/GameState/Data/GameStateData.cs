using System;
using System.Collections.Generic;
using Services.GameResources;

namespace Services.GameState.Data
{
	[Serializable]
	public sealed class GameStateData : ICloneable
	{
		public string version = "1.0";
		public int globalEntityId;
		public List<ResourceData> resources = new();
		// public CameraSettingsData cameraSettings;
		// public PlayerEntity player;

		public int GetEntityId() => ++globalEntityId;

		public object Clone() =>
			new GameStateData
			{
				// cameraSettings = this.cameraSettings.Clone() as CameraSettingsData,
				// player = this.player.Clone() as PlayerEntity
			};
	}
}