using _Code.Extensions;
using UnityEngine;

namespace _Code.Tank.Behaviour
{
    public class TankMovement
    {
        private readonly Vector2 Vector;
        
        private readonly float _speed;
        private readonly Rigidbody2D _rigidbody;

        public TankMovement(Rigidbody2D rigidbody, float speed)
        {
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 movement)
        {
            if (movement.x != 0)
                _rigidbody.velocity = movement.x * _speed * Vector.OneXAxis();
            else
                _rigidbody.velocity = movement.y * _speed * Vector.OneYAxis();
        }
    }
}