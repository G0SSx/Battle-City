using _Code.Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace _Code.Tiles
{
    public class EnemySpawnTile : MonoBehaviour
    {
        [HideInInspector] public float SpawnCooldown;
        [HideInInspector] public int EnemyMaxAmount;
        
        [SerializeField] private Transform _enemySpawnPoint;

        private IGameFactory _factory;
        private float _spawnTimer;
        private int _enemySpawnedAmount;

        [Inject]
        public void Construct(IGameFactory factory) => 
            _factory = factory;

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;
            
            if (_spawnTimer <= 0 && _enemySpawnedAmount < EnemyMaxAmount)
                SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            _factory.CreateEnemy(_enemySpawnPoint.position);
            _spawnTimer = SpawnCooldown;
            _enemySpawnedAmount++;
        }
    }
}