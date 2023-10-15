using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.Infrastructure.Services.Progress;
using _Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace _Code.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly GameObject _uiRootPrefab;
        private readonly GameObject _winWindow;
        private readonly GameObject _defeatWindow;
        private readonly GameObject _scoreText;
        private readonly GameObject _healthText;
        private readonly GameObject _enemyCounter;
        
        private IPersistentProgress _progress;
        private IGameFactory _gameFactory;
        private IMatchResult _matchResult;
        private Transform _uiRoot;

        public UIFactory()
        {
            _uiRootPrefab = AssetProvider.Load(PathProvider.UIRoot);
            _winWindow = AssetProvider.Load(PathProvider.WinWindow);
            _defeatWindow = AssetProvider.Load(PathProvider.DefeatWindow);
            _scoreText = AssetProvider.Load(PathProvider.ScoreCounter);
            _healthText = AssetProvider.Load(PathProvider.HealthCounter);
            _enemyCounter = AssetProvider.Load(PathProvider.EnemyCounter);
		}

        [Inject]
        private void Construct(IPersistentProgress progress, IGameFactory gameFactory, IMatchResult matchResult)
        {
			_progress = progress;
			_gameFactory = gameFactory;
			_matchResult = matchResult;
		}

        public void CreateUIRoot() => _uiRoot = Object.Instantiate(_uiRootPrefab).transform;

        public GameObject CreateWinWindow()
        {
            GameObject prefab = Object.Instantiate(_winWindow, _uiRoot);

            prefab.GetComponent<WinWindow>()
                .Init(_progress);

            return prefab;
        }

        public GameObject CreateDefeatWindow()
        {
            GameObject prefab = Object.Instantiate(_defeatWindow, _uiRoot);

            prefab.GetComponent<DefeatWindow>()
                .Init(_progress);

            return prefab;
        }

        public GameObject CreateScoreCounter()
        {
            GameObject prefab = Object.Instantiate(_scoreText, _uiRoot);
            
            prefab.GetComponent<ScoreCounter>()
                .Init(_progress, _gameFactory);

            return prefab;
        }

        public GameObject CreateHealthCounter()
        {
            GameObject player = Object.Instantiate(_healthText, _uiRoot);

            player.GetComponent<HealthCounter>()
                .Init(_gameFactory, _matchResult);

            return player;
        }

        public GameObject CreateEnemyCounter()
        {
            GameObject prefab = Object.Instantiate(_enemyCounter, _uiRoot);
            
            prefab.GetComponent<EnemyCounter>()
                .Init(_gameFactory, _matchResult);

            return prefab;
        }
    }
}