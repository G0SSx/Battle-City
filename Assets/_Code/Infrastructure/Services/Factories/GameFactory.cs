using System;
using _Code.Configs;
using _Code.Logic;
using _Code.Tank.Behaviour;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Code.Infrastructure.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        public event Action<TankHealth> OnEnemyCreated;
        public event Action<TankHealth> OnPlayerCreated;

        private readonly GameObject _playerPrefab;
        private readonly GameObject _enemyPrefab;
        private readonly GameObject _playerBulletPrefab;
        private readonly DiContainer _container;
        private readonly GameObject _enemyBulletPrefab;
        private readonly BulletConfig _bulletConfig;
        
        public GameFactory(GameObject playerPrefab, GameObject enemyPrefab, GameObject playerBulletPrefab,
            DiContainer container, GameObject enemyBulletPrefab, BulletConfig bulletConfig)
        {
            _playerPrefab = playerPrefab;
            _enemyPrefab = enemyPrefab;
            _playerBulletPrefab = playerBulletPrefab;
            _container = container;
            _enemyBulletPrefab = enemyBulletPrefab;
            _bulletConfig = bulletConfig;
        }

        public GameObject CreatePlayer(Vector2 position)
        {
            GameObject player = _container.InstantiatePrefab(_playerPrefab, position, Quaternion.identity, null);

            TankHealth playerHealth = player.GetComponent<TankHealth>();
            OnPlayerCreated?.Invoke(playerHealth);

            return player;
        }

        public GameObject CreatePlayerBullet(Vector3 position, Quaternion rotation)
        {
            GameObject bulletPrefab = Object.Instantiate(_playerBulletPrefab, position, rotation); 
            SetupBullet(bulletPrefab);
            
            return bulletPrefab;
        }

        public GameObject CreateEnemyBullet(Vector3 position, Quaternion rotation)
        {
            GameObject bulletPrefab = Object.Instantiate(_enemyBulletPrefab, position, rotation); 
            SetupBullet(bulletPrefab);
                
            return bulletPrefab;
        }

        public GameObject CreateEnemy(Vector2 position)
        {
            GameObject enemy = _container.InstantiatePrefab(_enemyPrefab, position, Quaternion.identity, null);
            TankHealth enemyHealth = enemy.GetComponent<TankHealth>();
            OnEnemyCreated?.Invoke(enemyHealth);

            return enemy;
        }

        private void SetupBullet(GameObject bulletPrefab)
        {
            bulletPrefab.GetComponent<PlayerBullet>()
                .Speed = _bulletConfig.Speed;
        }
    }
}