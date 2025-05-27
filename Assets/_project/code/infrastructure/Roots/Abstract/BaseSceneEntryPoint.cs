using infrastructure.DI;
using R3;
using UnityEngine;

namespace infrastructure.Roots.Abstract
{
	public abstract class BaseSceneEntryPoint : MonoBehaviour
	{
		public Observable<ExitParams> Run(DIContainer diContainer, EnterParams enterParams)
		{
			OnRun();
			return CreateExitSignal();
		}

		protected abstract void OnRun();
		protected abstract Observable<ExitParams> CreateExitSignal();
		protected abstract void InitWorld();
		protected abstract void InitUI();
	}
}