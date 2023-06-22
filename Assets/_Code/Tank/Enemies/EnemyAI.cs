using System;
using _Code.Configs;
using _Code.Infrastructure.Services.Factories;
using _Code.Tank.Behaviour;
using _Code.Tank.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Code.Tank.Enemies
{
    public class EnemyAI : BaseTank
    {
        private enum Direction { Up, Down, Right, Left }
        
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private TankHealth _health;
        
        private float _movementChoiceCooldown;
        private float _shootChoiceCooldown;
        private float _movementChoiceTimer;
        private float _shootChoiceTimer;
        private Direction _direction;
        private Direction[] _possibleDirections;
        private IGameFactory _factory;

        private bool _canShoot => _shootChoiceTimer <= 0f;
        
        [Inject]
        private void Construct(IGameFactory factory, EnemyConfig enemyConfig)
        {
            _factory = factory;
            MovementSpeed = enemyConfig.Speed;
            ShootingCooldown = enemyConfig.ShootingCooldown;
            _movementChoiceCooldown = enemyConfig.MovementChoiceCooldown;
            _shootChoiceCooldown = enemyConfig.ShootingCooldown;
            _health.Health = enemyConfig.Health;
        }

        private void Awake() =>
            CreateBehaviour();

        private void Start() =>
            _possibleDirections = Enum.GetValues(typeof(Direction)) as Direction[];

        private void Update()
        {
            UpdateChoiceCooldown();
            UpdateShootingCooldown();

            if (ChooseToChangeDirection())
                ChangeMovementDirection();

            tankVisual.UpdateVisual(movement);

            if ((ChooseToShoot() || SeePlayer()) && _canShoot)
                ShootAndResetChoiceTimer();
        }

        private void FixedUpdate() => 
            tankMovement.Move(movement);

        private bool SeePlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(tankSprite.transform.position, tankSprite.transform.up, 20f, _playerMask);

            if (hit.transform != null && hit.transform.TryGetComponent(out PlayerTank player))
                return true;

            return false;
        }

        private bool ChooseToShoot()
        {
            if (CantChooseToShoot())
                return false;

            bool choseToShoot = GetRandomBool();

            if (choseToShoot)
                return true;
            
            _shootChoiceCooldown += 0.1f;
            return false;
        }

        private bool ChooseToChangeDirection()
        {
            if (CantMakeChoice())
                return false;

            return GetRandomBool();
        }

        private void ChangeMovementDirection()
        {
            ChangeDirectionOnRandom();

            if (_direction == Direction.Down)
                movement = Vector2.down;
            else if (_direction == Direction.Left)
                movement = Vector2.left;
            else if (_direction == Direction.Right)
                movement = Vector2.right;
            else if (_direction == Direction.Up) 
                movement = Vector2.up;

            ResetMovementChoiceTimer();
        }

        private void ChangeDirectionOnRandom() => 
            _direction = _possibleDirections[Random.Range(0, _possibleDirections.Length)];

        private void ShootAndResetChoiceTimer()
        {
            ResetShootingChoiceTimer();
            Shoot();
        }

        private void Shoot() => 
            _factory.CreateEnemyBullet(bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        
        private void UpdateShootingCooldown() => 
            _shootChoiceTimer -= Time.deltaTime;

        private bool CantChooseToShoot() => 
            _shootChoiceTimer > 0f;

        private void ResetShootingChoiceTimer() => 
            _shootChoiceTimer = _shootChoiceCooldown;
        
        private void ResetMovementChoiceTimer() => 
            _movementChoiceTimer = _movementChoiceCooldown;

        private void UpdateChoiceCooldown() => 
            _movementChoiceTimer -= Time.deltaTime;

        private bool CantMakeChoice() => 
            _movementChoiceTimer > 0f;

        private static bool GetRandomBool() => 
            Random.Range(0, 2) == 0;
    }
}