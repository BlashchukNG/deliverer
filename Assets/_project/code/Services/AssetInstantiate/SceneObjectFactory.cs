using infrastructure.Coroutiner;
using infrastructure.Roots.AppRoot;
using Services.Updater;
using UnityEngine;

namespace Services.AssetInstantiate
{
	public sealed class SceneObjectFactory : ISceneObjectFactory
	{
		public CoroutineRunner CreateCoroutineRunner()
		{
			var coroutineRunner = new GameObject("[COROUTINE RUNNER]")
				.AddComponent<CoroutineRunner>();
			Object.DontDestroyOnLoad(coroutineRunner.gameObject);

			return coroutineRunner;
		}

		public IUpdateService CreateUpdater()
		{
			var updater = new GameObject("[UPDATE SERVICE]")
				.AddComponent<UpdateService>();

			return updater;
		}

		public UIRootView CreateUIRootView()
		{
			var prefab = Resources.Load<UIRootView>("root/ui root view");
			var obj = Object.Instantiate(prefab);
			Object.DontDestroyOnLoad(obj.gameObject);
			return obj;
		}
	}
}