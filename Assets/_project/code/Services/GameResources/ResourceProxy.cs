using R3;
using Services.GameResources.Configs;

namespace Services.GameResources
{
	public sealed class ResourceProxy
	{
		public string TypeID { get; }
		public string TitleLocKey { get; }
		public string DescriptionLocKey { get; }

		public ResourceType Type { get; }
		public ReactiveProperty<int> Amount { get; }

		public readonly ResourceData origin;
		

		public ResourceProxy(ResourceData data, ResourceConfig config)
		{
			origin = data;

			TypeID = data.typeId;
			Type = data.type;

			TitleLocKey = config.titleLocKey;
			DescriptionLocKey = config.descriptionLocKey;

			Amount = new ReactiveProperty<int>(data.amount);
			Amount.Skip(1).Subscribe(value => data.amount = value);
		}
	}
}