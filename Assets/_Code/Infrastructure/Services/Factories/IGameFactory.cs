using System;
using _Code.Tank.Behaviour;
using UnityEngine;

namespace _Code.Infrastructure.Services.Factories
{
    public interface IGameFactory
    {
        event Action<TankHealth> OnEnemyCreated;
        event Action<TankHealth> OnPlayerCreated;
        
        GameObject CreatePlayer(Vector2 position);
        GameObject CreatePlayerBullet(Vector3 position, Quaternion rotation);
        GameObject CreateEnemyBullet(Vector3 position, Quaternion rotation);
        GameObject CreateEnemy(Vector2 position);
    }
}