using System.Collections.Generic;
using Services.GameState.Data;
using Services.Settings.Configs.GameResources;
using UnityEngine;

namespace Services.Settings.Configs.Game
{
	[CreateAssetMenu(fileName = "settings game", menuName = "SETTINGS/new game settings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		public GameStateData baseSaveFile;
		public List<ResourceConfig> configsResources;
		//public PlayerConfig configPlayer;
	}
}