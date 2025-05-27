using System;
using System.Collections.Generic;
using infrastructure.DI;
using Services.CMD.Abstract;
using Services.GameState;

namespace Services.CMD
{
	public class CommandProcessor : ICommandProcessor
	{
		private readonly IGameStateProvider _gameStateProvider;
		private readonly Dictionary<Type, object> _handlesMap = new();


		public CommandProcessor(DIContainer diContainer)
		{
			_gameStateProvider = diContainer.Resolve<IGameStateProvider>();
		}

		public void RegisterHandler<TCommand>(ICommandHandler<TCommand> command)
			where TCommand : ICommand
		{
			_handlesMap[typeof(TCommand)] = command;
		}

		public bool ProcessCommand<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			if (_handlesMap.TryGetValue(command.GetType(), out object handler))
			{
				var handlerType = (ICommandHandler<TCommand>)handler;
				var result = handlerType.Handle(command);
				if (result) _gameStateProvider.SaveData();
				return result;
			}

			return false;
		}
	}
}