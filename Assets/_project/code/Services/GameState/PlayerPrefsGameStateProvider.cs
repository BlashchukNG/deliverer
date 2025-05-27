using infrastructure.DI;
using R3;
using Services.GameResources;
using Services.GameState.Data;
using Services.GameState.Proxy;
using Services.Settings;
using UnityEngine;

namespace Services.GameState
{
	public sealed class PlayerPrefsGameStateProvider : IGameStateProvider
	{
		private const string DATA_KEY = nameof(DATA_KEY);
		private const string SETTINGS_KEY = nameof(SETTINGS_KEY);

		public GameSettingsDataProxy Settings { get; private set; }
		public GameStateDataProxy Data { get; private set; }

		private readonly ISettingsProvider _settings;

		private GameSettingsData _originSettings;
		private GameStateData _originData;

		public PlayerPrefsGameStateProvider(DIContainer diContainer)
		{
			_settings = diContainer.Resolve<ISettingsProvider>();
		}


		#region Settings

		public Observable<GameSettingsDataProxy> LoadSettings()
		{
			if (!PlayerPrefs.HasKey(SETTINGS_KEY))
			{
				Settings = CreateSettingsFromAppSettings();
				SaveSettings();
			}
			else
			{
				var json = PlayerPrefs.GetString(SETTINGS_KEY);
				_originSettings = JsonUtility.FromJson<GameSettingsData>(json);
				Settings = new GameSettingsDataProxy(_originSettings);
				Debug.Log($"GameStateProvider: settings state loaded: {json}");
			}

			return Observable.Return(Settings);
		}

		public Observable<bool> SaveSettings()
		{
			var json = JsonUtility.ToJson(_originSettings, true);
			PlayerPrefs.SetString(SETTINGS_KEY, json);
			Debug.Log($"GameStateProvider: settings saved: {json}");
			return Observable.Return(true);
		}

		public Observable<bool> ResetSettings()
		{
			Settings = CreateSettingsFromAppSettings();
			SaveSettings();
			return Observable.Return(true);
		}

		private GameSettingsDataProxy CreateSettingsFromAppSettings()
		{
			_originSettings = _settings.AppSettings.settings.Clone() as GameSettingsData;
			Debug.Log($"GameStateProvider: settings created from settings: {JsonUtility.ToJson(_originSettings, true)}");
			return new GameSettingsDataProxy(_originSettings);
		}

		#endregion

		#region Data

		public Observable<GameStateDataProxy> LoadData()
		{
			if (!PlayerPrefs.HasKey(DATA_KEY))
			{
				Data = CreateDataFromGameSettings();
				SaveData();
			}
			else
			{
				var json = PlayerPrefs.GetString(DATA_KEY);
				_originData = JsonUtility.FromJson<GameStateData>(json);
				Data = new GameStateDataProxy(_originData, _settings.GameSettings.configsResources);
				Debug.Log($"GameStateProvider: data loaded: {json}");
			}

			return Observable.Return(Data);
		}

		public Observable<bool> SaveData()
		{
			var json = JsonUtility.ToJson(_originData, true);
			PlayerPrefs.SetString(DATA_KEY, json);
			Debug.Log($"GameStateProvider: data saved: {json}");
			return Observable.Return(true);
		}

		public Observable<bool> ResetData()
		{
			Data = CreateDataFromGameSettings();
			SaveData();
			return Observable.Return(true);
		}

		private GameStateDataProxy CreateDataFromGameSettings()
		{
			_originData = _settings.GameSettings.baseSaveFile.Clone() as GameStateData;
			foreach (var config in _settings.GameSettings.configsResources)
				_originData?.resources.Add(new ResourceData(config));

			Debug.Log($"GameStateProvider: data created from settings: {JsonUtility.ToJson(_originData, true)}");

			return new GameStateDataProxy(_originData, _settings.GameSettings.configsResources);
		}

		#endregion
	}
}