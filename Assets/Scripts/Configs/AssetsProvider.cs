using UnityEngine;

namespace Configs
{
	[CreateAssetMenu(fileName = "AssetsConfig", menuName = "Configs/Assets config")]
	public class AssetsProvider : ScriptableObject
	{
		public GameObject MainMenuPrefab, GameControllerPrefab, PlayerSpaceshipPrefab, BulletPrefab;
	}
}
