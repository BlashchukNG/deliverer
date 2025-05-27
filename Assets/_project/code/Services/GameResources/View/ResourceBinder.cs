using R3;
using TMPro;
using UnityEngine;

namespace Services.GameResources.View
{
	public sealed class ResourceBinder : MonoBehaviour
	{
		[SerializeField] private TMP_Text _tAmount;

		private readonly CompositeDisposable _subscriptions = new();

		public void Bind(ResourceViewModel viewModel)
		{
			_subscriptions.Add(viewModel.Amount.Subscribe(a => _tAmount.text = $"{a}"));
		}

		private void OnDestroy() => _subscriptions.Dispose();
	}
}