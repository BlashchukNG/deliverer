using UnityEngine;

namespace Services.Settings.Configs.Player
{
	[CreateAssetMenu(fileName = "config player", menuName = "SETTINGS/Configs/Player/PlayerConfig", order = 0)]
	public class PlayerConfig : ScriptableObject
	{
		public string prefabPlayer;
		//public LocomotionSettingsConfig locomotionSettings;
	}
}