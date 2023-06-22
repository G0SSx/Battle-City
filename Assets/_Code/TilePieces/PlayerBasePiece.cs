using System;
using _Code.Logic;
using UnityEngine;

namespace _Code.TilePieces
{
    public class PlayerBasePiece : MonoBehaviour, ITilePiece
    {
        public event Action OnDestroyed;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out PlayerBullet bullet))
            {
                bullet.SelfDestroy();
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}