using System;

namespace _Code.Data
{
    [Serializable]
    public class HighScore
    {
        public event Action OnChanged;
        
        public int Score;

        public void Add(int score)
        {
            Score += score;
            OnChanged?.Invoke();
        }
    }
}