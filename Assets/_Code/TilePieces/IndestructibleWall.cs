using _Code.Logic;
using UnityEngine;

namespace _Code.TilePieces
{
    public class IndestructibleWall : MonoBehaviour, ITilePiece
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerBullet bullet)) 
                bullet.SelfDestroy();
        }
    }
}