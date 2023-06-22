using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Code.UI
{
    public class RestartButton : MonoBehaviour
    {
        private const int GameSceneIndex = 0;
        
        [SerializeField] private Button _button;

        private void Start() => 
            _button.onClick.AddListener(LoadGameScene);

        private static void LoadGameScene() => 
            SceneManager.LoadScene(GameSceneIndex);
    }
}