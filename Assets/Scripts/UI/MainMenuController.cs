using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class MainMenuController : MonoBehaviour
	{
		[SerializeField] private Button _playButton;
		
		private Action _playAction;

		public void Init(Action playAction)
		{
			_playAction = playAction;

			_playButton.onClick.AddListener(OnPlayButtonClicked);
		}

		private void OnPlayButtonClicked()
		{
			_playAction?.Invoke();

			CleanUp();
		}

		public void CleanUp()
		{
			_playButton.onClick.RemoveAllListeners();

			Destroy(gameObject);
		}
	}
}
