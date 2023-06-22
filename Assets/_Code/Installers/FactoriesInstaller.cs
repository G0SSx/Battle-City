using _Code.Configs;
using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.Infrastructure.Services.Progress;
using _Code.Tiles.Factory;
using _Code.UI.Factory;
using UnityEngine;
using Zenject;

namespace _Code.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _playerBulletPrefab;
        [SerializeField] private GameObject _enemyBulletPrefab;
        [SerializeField] private GameObject _enemyPrefab;

        [Header("Configs")] 
        [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
        [SerializeField] private BulletConfig _bulletConfig;

        [Header("Tiles")]
        [SerializeField] private GameObject[] _destructibleTilePrefabs;
        [SerializeField] private GameObject[] _indestructibleTilePrefabs;
        [SerializeField] private GameObject _playerBaseTile;
        [SerializeField] private GameObject _enemySpawnTile;

        [Header("UI prefabs")]
        [SerializeField] private GameObject _uiRootPrefab;
        [SerializeField] private GameObject _winWindow;
        [SerializeField] private GameObject _looseWindow;
        [SerializeField] private GameObject _scoreText;
        [SerializeField] private GameObject _healthText;
        [SerializeField] private GameObject _enemyCounter;
        
        private IPersistentProgress _progress;

        [Inject]
        private void Construct(IPersistentProgress progress) => 
            _progress = progress;

        public override void InstallBindings()
        {
            IGameFactory gameFactory = CreateGameFactory();
            
            Container
                .Bind<IGameFactory>()
                .FromInstance(gameFactory)
                .AsSingle();

            Container
                .Bind<ITileFactory>()
                .FromInstance(new TileFactory(_destructibleTilePrefabs, _indestructibleTilePrefabs, _playerBaseTile,
                    _enemySpawnTile, Container, _enemySpawnerConfig))
                .AsSingle();

            IUIFactory uiFactory = new UIFactory(_uiRootPrefab, _winWindow, _looseWindow, _scoreText, _healthText,
                _enemyCounter, _progress, gameFactory);
            
            IMatchResult matchResult = new MatchResult(uiFactory);
            Container
                .Bind<IMatchResult>()
                .FromInstance(matchResult)
                .AsSingle();
            
            uiFactory.SetMatchResult(matchResult);
            Container
                .Bind<IUIFactory>()
                .FromInstance(uiFactory)
                .AsSingle();
        }

        private GameFactory CreateGameFactory() =>
            new(_playerPrefab, _enemyPrefab, _playerBulletPrefab, Container,
                _enemyBulletPrefab,
                _bulletConfig);
    }
}