using _Code.Tiles;
using _Code.Tiles.Factory;
using UnityEngine;

namespace _Code.Logic
{
    public class MapGenerator
    {
        private const int MapSize = 4;
        private const float TileSizeInUnits = 25f;
        private const float TileOffset = 12.5f;
        private const int IndestructibleTileMaxAmount = 2;
        
        private readonly Vector2 _enemySpawnTilePosition1 = new Vector2(0, 3);
        private readonly Vector2 _enemySpawnTilePosition2 = new Vector2(3, 3);
        private readonly Vector2 _playerBaseTilePosition = new Vector2(2, 0);
        
        private readonly ITileFactory _factory;

        private int _indestructibleTileAmount;
        
        public MapGenerator(ITileFactory factory) => 
            _factory = factory;

        public void Generate()
        {
            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    Vector2 tileMapPosition = new Vector2(x, y);
                    Vector2 tileSpawnPosition = new Vector2(x * TileSizeInUnits + TileOffset , y * TileSizeInUnits + TileOffset );

                    if (_enemySpawnTilePosition1 == tileMapPosition || _enemySpawnTilePosition2 == tileMapPosition)
                    {
                        CreateEnemySpawnTile(tileSpawnPosition);
                    }
                    else if (_playerBaseTilePosition == tileMapPosition)
                    {
                        _factory.CreateTileOfType(TileType.PlayerBase, tileSpawnPosition);
                    }
                    else
                    {
                        CreateRandomObstacleTile(tileSpawnPosition);
                    }
                }
            }
        }

        private GameObject CreateEnemySpawnTile(Vector2 tileSpawnPosition) => 
            _factory.CreateTileOfType(TileType.EnemySpawner, tileSpawnPosition);

        private GameObject CreateRandomObstacleTile(Vector2 tileSpawnPosition) => 
            _factory.CreateTileOfType(GetRandomObstacleType(), tileSpawnPosition);

        private TileType GetRandomObstacleType()
        {
            if (_indestructibleTileAmount == IndestructibleTileMaxAmount)
                return TileType.Destructible;
            
            return GetRandomObstacleTileAndAddIfIndestructible();
        }

        private TileType GetRandomObstacleTileAndAddIfIndestructible()
        {
            TileType randomObstacleTile = Random.Range(0, 2) == 0 ? TileType.Destructible : TileType.Indestructible;

            if (randomObstacleTile == TileType.Indestructible)
                _indestructibleTileAmount++;
            
            return randomObstacleTile;
        }
    }
}