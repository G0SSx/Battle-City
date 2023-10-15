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
        private IUIFactory _uiFactory;

        [Inject]
        private void Construct(ITileFactory tileFactory, IUIFactory uiFactory)
        {
            _tileFactory = tileFactory;
            _uiFactory = uiFactory;
        }

        private void Start()
        {
            GenerateMap();
            CreateUI();
        }

        private void CreateUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateEnemyCounter();
            _uiFactory.CreateHealthCounter();
            _uiFactory.CreateScoreCounter();
        }

        private void GenerateMap()
        {
            _mapGenerator = new MapGenerator(_tileFactory);
            _mapGenerator.Generate();
        }
    }
}