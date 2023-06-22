using UnityEngine;

namespace _Code.Logic
{
    public class MapEdge : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out PlayerBullet bullet)) 
                bullet.SelfDestroy();
        }
    }
}