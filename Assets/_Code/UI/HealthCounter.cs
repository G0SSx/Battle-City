using _Code.Infrastructure.Services;
using _Code.Infrastructure.Services.Factories;
using _Code.Tank.Behaviour;
using TMPro;
using UnityEngine;

namespace _Code.UI
{
    public class HealthCounter : MonoBehaviour
    {
        private const int DefaultHealthAmount = 3;
        
        [SerializeField] private TextMeshProUGUI _text;
        
        private IMatchResult _matchResult;

        public void Init(IGameFactory gameFactory, IMatchResult matchResult)
        {
            gameFactory.OnPlayerCreated += PlayerCreated;
            _matchResult = matchResult;
        }

        private void Start() => 
            SetDefaultHealthAmount();

        private void SetDefaultHealthAmount() => 
            _text.text = $"Health: {DefaultHealthAmount}";

        private void UpdateHealth(int newHealth)
        {
            _text.text = $"Health: {newHealth}";

            if (newHealth <= 0) 
                _matchResult.OnMatchLose();
        }

        private void PlayerCreated(TankHealth playerHealth)
        {
            UpdateHealth(playerHealth.Health);
            playerHealth.OnDamaged += () => UpdateHealth(playerHealth.Health);
        }
    }
}