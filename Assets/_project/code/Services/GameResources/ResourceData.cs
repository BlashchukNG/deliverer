using System;
using Services.GameResources.Configs;

namespace Services.GameResources
{
	[Serializable]
	public sealed class ResourceData
	{
		public string typeId;
		public ResourceType type;
		public int amount;

		public ResourceData(ResourceConfig config)
		{
			typeId = config.typeId;
			type = config.type;
			amount = config.amount;
		}
	}
}