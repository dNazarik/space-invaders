using System.Collections;
using Configs;
using Core;
using Gameplay.Spaceships;
using TMPro;
using UnityEngine;

namespace Gameplay
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private TMP_Text _countdownTimer;

		private IGameStateController _gameStateController;
		private ICommonFactory _commonFactory;
		private PlayerSpaceship _playerSpaceship;

		public void Init(IGameStateController gameStateController, ICommonFactory factory, AssetsProvider assetsProvider)
		{
			_gameStateController = gameStateController;
			_commonFactory = factory;

			CreatePlayerSpaceship(assetsProvider);

			StartCoroutine(StartGameDelayed());
		}

		private void CreatePlayerSpaceship(AssetsProvider assetsProvider)
		{
			_playerSpaceship = _commonFactory.InstantiateObject<PlayerSpaceship>(assetsProvider.PlayerSpaceshipPrefab);
			_playerSpaceship.Init(_gameStateController, assetsProvider, _commonFactory);
		}

		private IEnumerator StartGameDelayed()
		{
			_gameStateController.SetState(GameState.FreezeTime);

			var startDelay = 1;

			_countdownTimer.text = startDelay.ToString();

			while (startDelay > 0)
			{
				yield return new WaitForSeconds(1.0f);

				startDelay--;

				_countdownTimer.text = startDelay.ToString();
			}

			_countdownTimer.gameObject.SetActive(false);

			StartGame();
		}

		private void StartGame()
		{
			_gameStateController.SetState(GameState.Playing);
		}
	}
}
