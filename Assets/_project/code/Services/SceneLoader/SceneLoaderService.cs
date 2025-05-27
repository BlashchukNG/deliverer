using System.Collections;
using Constants;
using infrastructure.Coroutiner;
using infrastructure.DI;
using infrastructure.Roots.Abstract;
using infrastructure.Roots.AppRoot;
using R3;
using Services.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
	public sealed class SceneLoaderService : ISceneLoaderService
	{
		private DIContainer _cashedSceneDIContainer;

		private readonly WaitForSeconds _delayBetweenScenes = new(InfrastructureConstants.DELAY_BETWEEN_SCENES);
		private readonly WaitForSeconds _delayBeforeLoadScene = new(InfrastructureConstants.SHOW_HIDE_LOADING_SCREEN_DURATION);

		private readonly DIContainer _diContainer;
		private readonly UIRootView _uiRootView;
		private readonly CoroutineRunner _coroutineRunner;
		private readonly IGameStateProvider _gameStateProvider;

		public SceneLoaderService(DIContainer diContainer)
		{
			_diContainer = diContainer;
			_uiRootView = _diContainer.Resolve<UIRootView>();
			_coroutineRunner = _diContainer.Resolve<CoroutineRunner>();
			_gameStateProvider = _diContainer.Resolve<IGameStateProvider>();
		}

		#region Lobby

		public void LoadLobby(EnterParams enterParams = null) => _coroutineRunner.StartCoroutine(LoadLobbyRoutine(enterParams));

		private IEnumerator LoadLobbyRoutine(EnterParams enterParams)
		{
			_uiRootView.ShowLoadingScreen();
			_cashedSceneDIContainer?.Dispose();

			yield return _delayBeforeLoadScene;
			yield return LoadScene(Scenes.BOOT);
			yield return LoadScene(Scenes.LOBBY);
			yield return _delayBetweenScenes;
			yield return LoadGameState();

			var diContainer = _cashedSceneDIContainer = new DIContainer(_diContainer);
			var entryPoint = Object.FindFirstObjectByType<BaseSceneEntryPoint>();
			entryPoint.Run(diContainer, enterParams)
			          .Subscribe(exitParams =>
			          {
				          switch (exitParams.SceneName)
				          {
					          case Scenes.GAMEPLAY:
						          //LoadGameplay(exitParams.TargetSceneEnterParams.As<GameplayEnterParams>());
						          break;
				          }
			          });

			yield return _delayBeforeLoadScene;

			_uiRootView.HideLoadingScreen();
		}

		#endregion

		#region Gameplay

		public void LoadGameplay(EnterParams enterParams = null) => _coroutineRunner.StartCoroutine(LoadGameplayRoutine(enterParams));

		private IEnumerator LoadGameplayRoutine(EnterParams enterParams)
		{
			_uiRootView.ShowLoadingScreen();
			_cashedSceneDIContainer?.Dispose();

			yield return _delayBeforeLoadScene;
			yield return LoadScene(Scenes.BOOT);
			yield return LoadScene(Scenes.GAMEPLAY);
			yield return _delayBetweenScenes;
			yield return LoadGameState();

			var diContainer = _cashedSceneDIContainer = new DIContainer(_diContainer);
			var entryPoint = Object.FindFirstObjectByType<BaseSceneEntryPoint>();
			entryPoint.Run(diContainer, enterParams)
			          .Subscribe(exitParams =>
			          {
				          switch (exitParams.SceneName)
				          {
					          case Scenes.LOBBY:
						          //LoadLobby(exitParams.TargetSceneEnterParams.As<GarageEnterParams>());
						          break;
				          }
			          });

			yield return _delayBeforeLoadScene;

			_uiRootView.HideLoadingScreen();
		}

		#endregion

		private IEnumerator LoadGameState()
		{
			var isSettingsLoaded = false;
			_gameStateProvider.LoadSettings().Subscribe(_ => isSettingsLoaded = true);
			var isDataLoaded = false;
			_gameStateProvider.LoadData().Subscribe(_ => isDataLoaded = true);

			yield return new WaitUntil(() => isDataLoaded && isSettingsLoaded);
		}

		private IEnumerator LoadScene(string sceneName)
		{
			yield return SceneManager.LoadSceneAsync(sceneName);
		}
	}
}