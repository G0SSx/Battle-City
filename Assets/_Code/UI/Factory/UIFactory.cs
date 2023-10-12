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
        private readonly GameObject _looseWindow;
        private readonly GameObject _scoreText;
        private readonly GameObject _healthText;
        private readonly GameObject _enemyCounter;
        
        private IPersistentProgress _progress;
        private IGameFactory _gameFactory;
        private IMatchResult _matchResult;
        private Transform _uiRoot;

        public UIFactory(GameObject uiRoot, GameObject winWindow, GameObject looseWindow, GameObject scoreText, GameObject healthText, 
            GameObject enemyCounter)
        {
            _uiRootPrefab = uiRoot;
            _winWindow = winWindow;
            _looseWindow = looseWindow;
            _scoreText = scoreText;
            _healthText = healthText;
            _enemyCounter = enemyCounter;
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

        public GameObject CreateLooseWindow()
        {
            GameObject prefab = Object.Instantiate(_looseWindow, _uiRoot);

            prefab.GetComponent<LooseWindow>()
                .Init(_progress);

            return prefab;
        }

        public GameObject CreateScoreText()
        {
            GameObject prefab = Object.Instantiate(_scoreText, _uiRoot);
            
            prefab.GetComponent<ScoreCounter>()
                .Init(_progress, _gameFactory);

            return prefab;
        }

        public GameObject CreateHealth()
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