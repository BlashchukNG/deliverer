using infrastructure.Coroutiner;
using infrastructure.Roots.AppRoot;
using Services.Updater;

namespace Services.AssetInstantiate
{
	public interface ISceneObjectFactory
	{
		CoroutineRunner CreateCoroutineRunner();
		UIRootView CreateUIRootView();
		IUpdateService CreateUpdater();
	}
}