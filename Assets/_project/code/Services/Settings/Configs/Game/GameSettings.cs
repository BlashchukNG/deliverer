using System.Collections.Generic;
using Services.GameResources.Configs;
using Services.GameState.Data;
using UnityEngine;

namespace Services.Settings
{
	[CreateAssetMenu(fileName = "settings game", menuName = "SETTINGS/new game settings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		public GameStateData baseSaveFile;
		public List<ResourceConfig> configsResources;
		//public PlayerConfig configPlayer;
	}
}