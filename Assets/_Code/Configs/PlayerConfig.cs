using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float ShootingCooldown;
        public float Speed;
        public int Health;
    }
}