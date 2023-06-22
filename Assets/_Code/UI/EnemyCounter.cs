using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.Tank.Behaviour;
using TMPro;
using UnityEngine;

namespace _Code.UI
{
    public class EnemyCounter : MonoBehaviour
    {
        private const int DefaultEnemyAmount = 20;
        
        [SerializeField] private TextMeshProUGUI _enemyCounter;

        private IGameFactory _factory;
        private int _enemyAmount;
        private IMatchResult _matchResultService;

        public void Init(IGameFactory factory, IMatchResult matchResultService)
        {
            _factory = factory;
            _factory.OnEnemyCreated += EnemyCreated;

            _matchResultService = matchResultService;
        }

        private void Start() => 
            SetDefaultScore();

        private void SetDefaultScore()
        {
            _enemyAmount = DefaultEnemyAmount;
            _enemyCounter.text = $"Enemies left: {DefaultEnemyAmount}";
        }

        private void EnemyDied()
        {
            _enemyCounter.text = $"Enemies left: {--_enemyAmount}";

            if (_enemyAmount == 0) 
                _matchResultService.MatchWon();
        }

        private void EnemyCreated(TankHealth enemyHealth) => 
            enemyHealth.OnDeath += EnemyDied;
    }
}