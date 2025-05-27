using System;

namespace Services.GameState.Data
{
	[Serializable]
	public sealed class GameSettingsData : ICloneable
	{
		public float volumeMusic;
		public float volumeSFX;

		public object Clone() => MemberwiseClone();
	}
}