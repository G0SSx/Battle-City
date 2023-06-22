using UnityEngine;

namespace _Code.Tank.Behaviour
{
    public class TankVisual
    {
        private readonly SpriteRenderer _tankSprite;

        public TankVisual(SpriteRenderer tankSprite)
        {
            _tankSprite = tankSprite;
        }
        
        public void UpdateVisual(Vector2 movement)
        {
            if (movement.x != 0)
                _tankSprite.transform.rotation = Quaternion.Euler(0, 0, movement.x > 0.01 ? 270 : 90);
            else if (movement.y != 0)
                _tankSprite.transform.rotation = Quaternion.Euler(0, 0, movement.y > 0.01 ? 0 : 180);
        }
    }
}