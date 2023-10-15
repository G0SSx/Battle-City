using UnityEngine;

namespace _Code.UI.Factory
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        GameObject CreateWinWindow();
        GameObject CreateDefeatWindow();
        GameObject CreateScoreCounter();
        GameObject CreateHealthCounter();
        GameObject CreateEnemyCounter();
    }
}