using System;
using _Code.Logic;
using UnityEngine;

namespace _Code.Tank.Behaviour
{
    public class TankHealth : MonoBehaviour
    {
        public event Action OnDamaged;
        public event Action OnDeath;
        
        [HideInInspector] public int Health;

        private PlayerBullet _lastPlayerBullet;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out PlayerBullet bullet))
            {
                bullet.SelfDestroy();

                if (bullet != _lastPlayerBullet)
                {
                    DecreaseHealth();
                    OnDamaged?.Invoke();
                    _lastPlayerBullet = bullet;
                }
            }
        }

        private void DecreaseHealth()
        {
            Health--;

            if (Health <= 0)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}