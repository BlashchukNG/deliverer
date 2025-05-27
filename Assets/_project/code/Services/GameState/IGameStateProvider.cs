using R3;
using Services.GameState.Proxy;

namespace Services.GameState
{
	public interface IGameStateProvider
	{
		public GameSettingsDataProxy Settings { get; }
		public GameStateDataProxy Data { get; }


		public Observable<GameSettingsDataProxy> LoadSettings();
		public Observable<bool> SaveSettings();
		public Observable<bool> ResetSettings();
		
		public Observable<GameStateDataProxy> LoadData();
		public Observable<bool> SaveData();
		public Observable<bool> ResetData();
	}
}