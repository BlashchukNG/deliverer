using R3;
using Services.GameState.Data;

namespace Services.GameState.Proxy
{
	public sealed class GameSettingsDataProxy
	{
		public ReactiveProperty<float> VolumeMusic { get; }
		public ReactiveProperty<float> VolumeSFX { get; }

		public GameSettingsDataProxy(GameSettingsData data)
		{
			VolumeMusic = new ReactiveProperty<float>(data.volumeMusic);
			VolumeSFX = new ReactiveProperty<float>(data.volumeSFX);

			VolumeMusic.Skip(1).Subscribe(value => data.volumeMusic = value);
			VolumeSFX.Skip(1).Subscribe(value => data.volumeSFX = value);
		}
	}
}