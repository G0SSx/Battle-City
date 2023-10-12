using _Code.Configs;
using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
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

		public override void InstallBindings()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle()
                .WithArguments(_playerPrefab, _enemyPrefab, _playerBulletPrefab, Container, _enemyBulletPrefab, _bulletConfig);

            Container
                .Bind<ITileFactory>()
                .To<TileFactory>()
				.AsSingle()
				.WithArguments(_destructibleTilePrefabs, _indestructibleTilePrefabs, _playerBaseTile, _enemySpawnTile, Container, 
                _enemySpawnerConfig);

            Container
                .Bind<IMatchResult>()
                .To<MatchResult>()
                .AsSingle();
            
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
				.AsSingle()
				.WithArguments(_uiRootPrefab, _winWindow, _looseWindow, _scoreText, _healthText, _enemyCounter);

			/*
			1. Можно давать разньіе реализации интерфейса по Id
            Container
                .Bind<IMatchResult>()
                .To<MatchResult>()
                .AsSingle()
                .WithConcreteId("Hello world");

            [Inject(Id = "Hello world")]
            private IMatchResult _matchResult;

            2. Можно вьіставлять условия инджекции
            Container
                .Bind<IMatchResult>()
                .To<MathResult>()
                .AsSingle()
                .When(obj => obj.type == typeof(UIFactory));
             
			 3. Дефолтное значение инджекции AsTransient() а не AsInstance()
			 */
		}
	}
}