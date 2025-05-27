using System.Collections.Generic;
using Services.Settings.Configs.GameResources;

namespace Services.GameState.Proxy
{
	public sealed class GameStateDataProxy
	{
		private readonly Data.GameStateData _stateData;
		private readonly List<ResourceConfig> _configs;
		public string Version { get; }

		//public ObservableList<ResourceProxy> Resources { get; } = new();
		// public CameraSettingsDataProxy CameraSettings { get; }
		// public PlayerEntityProxy Player { get; }


		public GameStateDataProxy(Data.GameStateData stateData, List<ResourceConfig> configs)
		{
			_stateData = stateData;
			_configs = configs;
			Version = stateData.version;
			// Player = new PlayerEntityProxy(state.player);
			// CameraSettings = new CameraSettingsDataProxy(state.cameraSettings);

			InitResources(stateData);
		}

		private void InitResources(Data.GameStateData stateData)
		{
			// state.resources.ForEach(resource => Resources.Add(new ResourceProxy(resource, _configs.First(c => c.type == resource.type))));
			//
			// Resources.ObserveAdd().Subscribe(e => { state.resources.Add(e.Value.origin); });
			//
			// Resources.ObserveAdd().Subscribe(e => { state.resources.Remove(state.resources.FirstOrDefault(resource => resource.type == e.Value.Type)); });
		}

		public int GetEntityId() => _stateData.GetEntityId();
	}
}