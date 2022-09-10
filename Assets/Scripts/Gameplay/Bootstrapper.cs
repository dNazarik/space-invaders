using Configs;
using Core;
using UI;
using UnityEngine;

namespace Gameplay
{
	public class Bootstrapper : MonoBehaviour
	{
		[SerializeField] private Transform _canvas;
		[SerializeField] private AssetsProvider _assetsProvider;

		private ICommonFactory _commonFactory;

		private void Awake()
		{
			_commonFactory = new CommonFactory();

			ShowMainMenu();
		}

		private void ShowMainMenu()
		{
			var menu = _commonFactory.InstantiateObject<MainMenuController>(_assetsProvider.MainMenuPrefab, _canvas);
			menu.Init(null);
		}
	}
}
