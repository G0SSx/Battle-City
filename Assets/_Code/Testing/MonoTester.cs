using UnityEngine;

namespace Assets._Code.Testing {
	public class MonoTester : MonoBehaviour {
		private DestructibleTile[] _destructibleTilePrefabs;
		private IndestructibleTile[] _indestructibleTilePrefabs;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.F)) TryLoadAssets();
			if (Input.GetKeyDown(KeyCode.C)) CheckAssets();
		}

		private void CheckAssets() {
			Debug.Log("Check: ");

			if (_destructibleTilePrefabs != null) {
				for (int prefabId = 0; prefabId < _destructibleTilePrefabs.Length; prefabId++) {
					Debug.Log($"Destructible tile Id {prefabId} is null - {_destructibleTilePrefabs[prefabId] == null}");
				}
			}

			if (_indestructibleTilePrefabs != null) {
				for (int prefabId = 0; prefabId < _indestructibleTilePrefabs.Length; prefabId++) {
					Debug.Log($"Indestructible tile Id {prefabId} is null - {_indestructibleTilePrefabs[prefabId] == null}");
				}
			}
		}

		private void TryLoadAssets() {
			Debug.Log("Load: ");

			_destructibleTilePrefabs = AssetProvider.LoadAll<DestructibleTile>(PathProvider.DestructibleTile);
			_indestructibleTilePrefabs = AssetProvider.LoadAll<IndestructibleTile>(PathProvider.IndestructibleTile);

			Debug.Log($"Length after check: \nDestructible {_destructibleTilePrefabs.Length} \nIndestructible {_indestructibleTilePrefabs.Length}");
		}
	}
}
