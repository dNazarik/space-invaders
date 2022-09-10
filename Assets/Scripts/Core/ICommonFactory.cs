using UnityEngine;

namespace Core
{
	public interface ICommonFactory
	{
		T InstantiateObject<T>(GameObject prefab, Transform parent = null) where T : Object;
	}
}