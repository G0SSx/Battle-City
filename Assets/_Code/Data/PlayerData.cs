using System;

namespace _Code.Data
{
    [Serializable]
    public class PlayerData
    {
        public HighScore HighScore;

        public PlayerData() => 
            HighScore = new();
    }
}