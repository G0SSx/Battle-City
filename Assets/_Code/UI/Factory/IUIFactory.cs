using _Code.Infrastructure.Services;
using UnityEngine;

namespace _Code.UI.Factory
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        GameObject CreateWinWindow();
        GameObject CreateLooseWindow();
        GameObject CreateScoreText();
        GameObject CreateHealth();
        GameObject CreateEnemyCounter();
    }
}