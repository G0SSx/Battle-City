using _Code.Configs;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Code.Tiles.Factory
{
    public class TileFactory : ITileFactory
    {
        private readonly DestructibleTile[] _destructibleTilePrefabs;
        private readonly IndestructibleTile[] _indestructibleTilePrefabs;
        private readonly GameObject _playerBaseTile;
        private readonly GameObject _enemySpawnTile;
        private readonly EnemySpawnerConfig _enemySpawnerConfig;
        private readonly DiContainer _container;

        public TileFactory(DiContainer container, EnemySpawnerConfig enemySpawnerConfig)
        {
            _container = container;
            _enemySpawnerConfig = enemySpawnerConfig;
            
            _destructibleTilePrefabs = AssetProvider.LoadAll<DestructibleTile>(PathProvider.DestructibleTile);
            _indestructibleTilePrefabs = AssetProvider.LoadAll<IndestructibleTile>(PathProvider.IndestructibleTile);
            _playerBaseTile = AssetProvider.Load(PathProvider.PlayerBaseTile);
            _enemySpawnTile = AssetProvider.Load(PathProvider.EnemySpawnTile);
		}
        
        public GameObject CreateTileOfType(TileType type, Vector2 position)
        {
            switch (type)
            {
                case TileType.PlayerBase:
                    return InstantiateTileWithZenject(_playerBaseTile, position);
                case TileType.Destructible:
                    return InstantiateTileAtPosition(RandomDestructible().gameObject, position);
                case TileType.Indestructible:
                    return InstantiateTileAtPosition(RandomIndestructible().gameObject, position);
                case TileType.EnemySpawner:
                    GameObject prefab = InstantiateTileWithZenject(_enemySpawnTile, position);
                    SetupEnemySpawner(prefab);
                    return prefab;
            }

            return null;
        }

        private GameObject InstantiateTileWithZenject(GameObject tile, Vector2 position) => 
            _container.InstantiatePrefab(tile, position, Quaternion.identity, null);

        private GameObject InstantiateTileAtPosition(GameObject tile, Vector2 position) => 
            Object.Instantiate(tile, position, Quaternion.identity);

        private DestructibleTile RandomDestructible() => _destructibleTilePrefabs[Random.Range(0, _destructibleTilePrefabs.Length)];

        private IndestructibleTile RandomIndestructible() => _indestructibleTilePrefabs[Random.Range(0, _indestructibleTilePrefabs.Length)];

        private void SetupEnemySpawner(GameObject prefab)
        {
            EnemySpawnTile spawnTile = prefab.GetComponent<EnemySpawnTile>();
            spawnTile.SpawnCooldown = _enemySpawnerConfig.SpawnCooldown;
            spawnTile.EnemyMaxAmount = _enemySpawnerConfig.EnemyMaxAmount;
        }
    }
}