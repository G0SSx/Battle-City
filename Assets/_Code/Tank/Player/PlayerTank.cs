using _Code.Configs;
using _Code.Infrastructure.Services.Factories;
using _Code.Tank.Behaviour;
using UnityEngine;
using Zenject;

namespace _Code.Tank.Player
{
    public class PlayerTank : BaseTank
    {
        private float _shootingCooldown;
        private float _shootingTimer;

        [SerializeField] private TankHealth _health;
        
        private bool _canShoot => _shootingTimer <= 0;
        private IGameFactory _factory;
        
        [Inject]
        private void Construct(IGameFactory factory, PlayerConfig playerConfig)
        {
            _factory = factory;
            MovementSpeed = playerConfig.Speed;
            ShootingCooldown = playerConfig.ShootingCooldown;
            _shootingCooldown = playerConfig.ShootingCooldown;
            _health.Health = playerConfig.Health;
        }

        private void Awake() =>
            CreateBehaviour();
        
        private void Update()
        {
            UpdateInput();
            UpdateCooldown();
            tankVisual.UpdateVisual(movement);
            
            if (Input.GetMouseButton(0) && _canShoot)
                ShootAndResetTimer();
        }

        private void ShootAndResetTimer()
        {
            Shoot();
            ResetShootingTimer();
        }

        private void Shoot() => 
            _factory.CreatePlayerBullet(bulletSpawnTransform.position, bulletSpawnTransform.rotation);

        private void ResetShootingTimer() => 
            _shootingTimer = _shootingCooldown;

        private void UpdateCooldown() => 
            _shootingTimer -= Time.deltaTime;

        private void FixedUpdate() => 
            tankMovement.Move(movement);

        private void UpdateInput()
        {
            movement.x = Input.GetAxisRaw(Horizontal);
            movement.y = Input.GetAxisRaw(Vertical);
        }
    }
}