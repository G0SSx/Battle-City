using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(menuName = "Configs/EnemySpawnerConfig", fileName = "EnemySpawner")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        public float SpawnCooldown;
        public int EnemyMaxAmount;
    }
}