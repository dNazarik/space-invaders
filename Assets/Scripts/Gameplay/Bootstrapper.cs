using Configs;
using Core;
using UI;
using UnityEngine;

namespace Gameplay
{
	public class Bootstrapper : MonoBehaviour
	{
		[SerializeField] private AssetsProvider _assetsProvider;

		private ICommonFactory _commonFactory;
		private IGameStateController _gameStateController;
		private GameController _gameController;

		private void Awake()
		{
			_commonFactory = new CommonFactory();
			_gameStateController = new GameStateController();

			ShowMainMenu();
		}

		private void ShowMainMenu()
		{
			var menu = _commonFactory.InstantiateObject<MainMenuController>(_assetsProvider.MainMenuPrefab);
			menu.Init(PlayGame);
		}

		private void PlayGame()
		{
			_gameController = _commonFactory.InstantiateObject<GameController>(_assetsProvider.GameControllerPrefab);
			_gameController.Init(_gameStateController, _commonFactory, _assetsProvider);
		}
	}
}
