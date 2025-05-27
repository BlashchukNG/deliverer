using infrastructure.Roots.Abstract;

namespace Services.SceneLoader
{
	public interface ISceneLoaderService
	{
		void LoadLobby(EnterParams enterParams = null);
		void LoadGameplay(EnterParams enterParams = null);
	}
}