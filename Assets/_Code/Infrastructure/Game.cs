using _Code.Infrastructure.Services.Factories;
using _Code.Logic;
using _Code.Tiles.Factory;
using _Code.UI.Factory;
using UnityEngine;
using Zenject;

namespace _Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        private MapGenerator _mapGenerator;
        private ITileFactory _tileFactory;
        private IGameFactory _gameFactory;
        private IUIFactory _uiFactory;

        [Inject]
        private void Construct(ITileFactory tileFactory, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _tileFactory = tileFactory;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        private void Awake() => 
            DontDestroyOnLoad(gameObject);

        private void Start()
        {
            GenerateMap();
            CreateUI();
        }

        private void CreateUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateEnemyCounter();
            _uiFactory.CreateHealth();
            _uiFactory.CreateScoreText();
        }

        private void GenerateMap()
        {
            _mapGenerator = new MapGenerator(_tileFactory);
            _mapGenerator.Generate();
        }
    }
}