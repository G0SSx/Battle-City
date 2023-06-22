using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.Logic;
using UnityEngine;
using Zenject;

namespace _Code.Tiles
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        
        private IGameFactory _factory;
        private GameObject _playerObject;
        private IMatchResult _matchResultService;

        [Inject]
        private void Init(IGameFactory factory, IMatchResult matchResultService)
        {
            _factory = factory;
            _matchResultService = matchResultService;
        }

        private void Start()
        {
            if (_playerSpawnPoint == null)
                return;
            
            _playerObject = _factory.CreatePlayer(_playerSpawnPoint.position);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out PlayerBullet bullet))
            {
                bullet.SelfDestroy();
                Destroy(gameObject);
                Destroy(_playerObject);
                _matchResultService.OnMatchLose();
            }
        }
    }
}