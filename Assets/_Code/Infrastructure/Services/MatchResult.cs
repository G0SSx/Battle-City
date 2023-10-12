using System;
using _Code.UI.Factory;
using _Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace _Code.Infrastructure.Services
{
    public class MatchResult : IMatchResult
    {
        public bool IsEnded { get; private set; }
        public Action OnMatchLose { get; }
        public Action MatchWon { get; }

        private IUIFactory _uiFactory;

        public MatchResult()
        {
            OnMatchLose += LoseMatch;
            MatchWon += WinMatch;
		}

        [Inject]
        private void Construct(IUIFactory uiFactory)
        {
			_uiFactory = uiFactory;
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