using _Code.TilePieces;
using UnityEngine;

namespace _Code.Tank.Behaviour
{
    public class TankOffset : MonoBehaviour
    {
        private const float TankSize = 2.4f;
        private const float Offset = 0.1f;
        private const float RaycastSize = TankSize + Offset;
        
        [SerializeField] private LayerMask _wallLayer;
        
        private void Update()
        {
            MoveIfTooClose(Vector2.up);
            MoveIfTooClose(Vector2.down);
            MoveIfTooClose(Vector2.right);
            MoveIfTooClose(Vector2.left);
        }

        private void MoveIfTooClose(Vector3 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, RaycastSize, _wallLayer);

            if (hit.transform != null && hit.transform.TryGetComponent(out ITilePiece tile))
                transform.position -= direction * 0.0001f;
        }
    }
}