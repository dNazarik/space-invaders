using Configs;
using Core;
using UnityEngine;

namespace Gameplay.Spaceships
{
	public class PlayerSpaceship : MonoBehaviour
	{
		private const float ScreenLimit = 8.0f;

		[SerializeField] private Transform _transform, _rocketSpawner;
		[SerializeField] private float _speed;
		
		private CommonPool<SpaceshipBullet> _bullets;
		private IGameStateController _gameStateController;
		private ICommonFactory _factory;
		private AssetsProvider _assetsProvider;

		public void Init(IGameStateController gameStateController, AssetsProvider provider, ICommonFactory factory)
		{
			_gameStateController = gameStateController;
			_assetsProvider = provider;
			_factory = factory;

			_bullets = new CommonPool<SpaceshipBullet>();
		}

		public void Update()
		{
			if(_gameStateController.GameState != GameState.Playing)
				return;

			PlayerInput();

			ValidatePlayerPosition();
		}

		private void PlayerInput()
		{
			if(Input.GetKey(KeyCode.LeftArrow))
				MovePlayer(true);
			else if(Input.GetKey(KeyCode.RightArrow))
				MovePlayer(false);

			if(Input.GetKeyDown(KeyCode.Space))
				DoShot();
		}

		private void MovePlayer(bool isLeft) =>
			_transform.Translate((isLeft ? Vector3.left : Vector3.right) * _speed * Time.deltaTime);

		private void ValidatePlayerPosition()
		{
			_transform.localPosition = _transform.localPosition.x switch
			{
				< -ScreenLimit => new Vector3(-ScreenLimit, _transform.localPosition.y, _transform.localPosition.z),
				> ScreenLimit => new Vector3(ScreenLimit, _transform.localPosition.y, _transform.localPosition.z),
				_ => _transform.localPosition
			};
		}

		private void DoShot()
		{
			var bullet = _bullets.TryGetFromPool();

			if (bullet == null)
				bullet = _factory.InstantiateObject<SpaceshipBullet>(_assetsProvider.BulletPrefab);

			bullet.Init(_rocketSpawner.position, SaveBulletToPool);
		}

		private void SaveBulletToPool(SpaceshipBullet bullet) => _bullets.AddToPool(bullet);
	}
}
