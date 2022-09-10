using System;
using Core;
using UnityEngine;

namespace Gameplay.Spaceships
{
	public class SpaceshipBullet : MonoBehaviour
	{
		[SerializeField] private GameObject _gameObject;
		[SerializeField] private Transform _transform;
		[SerializeField] private float _speed;

		private bool _isLaunched;
		private Action<SpaceshipBullet> _onBulletHit;

		public void Init(Vector3 position, Action<SpaceshipBullet> onBulletHit)
		{
			_onBulletHit = onBulletHit;
			_transform.position = position;
			_gameObject.SetActive(true);

			_isLaunched = true;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.transform.CompareTag(Constants.WallTag))
				Hide();
		}

		private void Hide()
		{
			_isLaunched = false;

			_onBulletHit?.Invoke(this);

			_gameObject.SetActive(false);
		}

		private void Update() => MoveBullet();

		private void MoveBullet()
		{
			if (!_isLaunched)
				return;

			_transform.Translate(Vector3.up * _speed * Time.deltaTime);
		}
	}
}
