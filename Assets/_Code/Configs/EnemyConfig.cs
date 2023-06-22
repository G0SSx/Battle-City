using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(menuName = "Configs/EnemyConfig", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public float MovementChoiceCooldown;
        public float ShootChoiceCooldown;
        public float ShootingCooldown;
        public float Speed;
        public int Health;
    }
}