using R3;

namespace Services.GameResources.View
{
	public sealed class ResourceViewModel
	{
		public string TypeID { get; }
		public string TitleLocKey { get; }
		public string DescriptionLocKey { get; }
		public ResourceType Type { get; }
		public ReadOnlyReactiveProperty<int> Amount { get; }

		public ResourceViewModel(ResourceProxy resource)
		{
			TypeID = resource.TypeID;
			TitleLocKey = resource.TitleLocKey;
			DescriptionLocKey = resource.DescriptionLocKey;
			Type = resource.Type;
			Amount = resource.Amount;
		}
	}
}