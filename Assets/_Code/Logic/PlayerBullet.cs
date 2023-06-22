using UnityEngine;

namespace _Code.Logic
{
    public class PlayerBullet : MonoBehaviour
    {
        [HideInInspector] public float Speed;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private void Awake() =>
            Invoke(nameof(SelfDestroy), 5f);

        private void FixedUpdate() => 
            _rigidbody.velocity = transform.up * Speed;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out PlayerBullet bullet))
            {
                if (bullet != null)
                    bullet.SelfDestroy();
                
                SelfDestroy();
            }
        }

        public void SelfDestroy() => 
            Destroy(gameObject);
    }
}