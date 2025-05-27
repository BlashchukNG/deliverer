using Services.GameResources;
using UnityEngine;

namespace Services.Settings.Configs.GameResources
{
	[CreateAssetMenu(fileName = "config resource", menuName = "SETTINGS/Configs/Resources/ResourceConfig", order = 0)]
	public class ResourceConfig : ScriptableObject
	{
		public string typeId;
		public string titleLocKey;
		public string descriptionLocKey;

		public ResourceType type;
		public int amount;
	}
}