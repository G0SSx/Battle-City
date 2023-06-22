using _Code.Infrastructure.Services.Factories;
using _Code.Infrastructure.Services.Progress;
using _Code.Tank.Behaviour;
using TMPro;
using UnityEngine;

namespace _Code.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        private const int ScoreForKill = 100;
        
        [SerializeField] private TextMeshProUGUI _scoreCounter;

        private IPersistentProgress _progress;
        private IGameFactory _gameFactory;

        public void Init(IPersistentProgress progress, IGameFactory gameFactory)
        {
            _progress = progress;
            _gameFactory = gameFactory;

            _gameFactory.OnEnemyCreated += SubscribeOnEnemyDeath;
        }
        
        private void UpdateScore() =>
            _scoreCounter.text = $"Score: {_progress.Progress.HighScore.Score}";

        private void EnemyKilled()
        {
            _progress.Progress.HighScore.Add(ScoreForKill);
            UpdateScore();
        }

        private void SubscribeOnEnemyDeath(TankHealth enemyHealth) => 
            enemyHealth.OnDeath += EnemyKilled;
    }
}