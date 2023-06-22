using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.TilePieces;
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
        private PlayerBasePiece _basePiece;
        
        [Inject]
        private void Init(IGameFactory factory, IMatchResult matchResultService)
        {
            _factory = factory;
            _matchResultService = matchResultService;
        }

        private void Awake()
        {
            _basePiece = GetComponentInChildren<PlayerBasePiece>();
            _basePiece.OnDestroyed += LoseGame;
        }
        
        private void Start()
        {
            if (_playerSpawnPoint == null)
                return;
            
            _playerObject = _factory.CreatePlayer(_playerSpawnPoint.position);
        }

        private void LoseGame()
        {
            _matchResultService.OnMatchLose();
            Destroy(_playerObject);
            Destroy(gameObject);
        }
    }
}