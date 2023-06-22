using System;
using _Code.UI.Factory;
using _Code.UI.Windows;
using UnityEngine;

namespace _Code.Infrastructure.Services
{
    public class MatchResult : IMatchResult
    {
        public bool IsEnded { get; private set; }
        public Action OnMatchLose { get; }
        public Action MatchWon { get; }

        private readonly IUIFactory _uiFactory;

        public MatchResult(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            
            OnMatchLose += LoseMatch;
            MatchWon += WinMatch;
        }

        private void WinMatch()
        {
            GameObject winWindowPrefab = _uiFactory.CreateWinWindow();
            
            IsEnded = true;
            
            winWindowPrefab.GetComponent<WinWindow>()
                    .Show();
        }

        private void LoseMatch()
        {
            GameObject looseWindowPrefab = _uiFactory.CreateLooseWindow();
            
            IsEnded = true;
            
            looseWindowPrefab.GetComponent<LooseWindow>()
                .Show();
        }
    }
}