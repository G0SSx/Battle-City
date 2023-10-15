using _Code.Infrastructure.Services.Progress;
using TMPro;
using UnityEngine;

namespace _Code.UI.Windows
{
    public class DefeatWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private IPersistentProgress _progress;

        public void Init(IPersistentProgress progress) => 
            _progress = progress;

        public void Show()
        {
            gameObject.SetActive(true);

            _scoreText.text = $"Score: {_progress.Progress.HighScore.Score}";
        }
    }
}