using Services.GameState.Data;
using UnityEngine;

namespace Services.Settings.Configs.App
{
	[CreateAssetMenu(fileName = "settings app", menuName = "SETTINGS/new app settings", order = 0)]
	public class AppSettings : ScriptableObject
	{
		public GameSettingsData settings;
	}
}