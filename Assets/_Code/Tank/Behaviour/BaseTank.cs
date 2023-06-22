using UnityEngine;

namespace _Code.Tank.Behaviour
{
    public abstract class BaseTank : MonoBehaviour
    {
        [HideInInspector] public float MovementSpeed;
        [HideInInspector] public float ShootingCooldown;

        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        [SerializeField] protected Rigidbody2D tankRigidbody;
        [SerializeField] protected Transform bulletSpawnTransform;
        [SerializeField] protected SpriteRenderer tankSprite;

        protected TankMovement tankMovement;
        protected TankVisual tankVisual;
        protected Vector2 movement;
        
        protected void CreateBehaviour()
        {
            tankMovement = new TankMovement(tankRigidbody, MovementSpeed);
            tankVisual = new TankVisual(tankSprite);
        }
    }
}