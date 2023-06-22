using _Code.Configs;
using UnityEngine;
using Zenject;

namespace _Code.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            Container
                .Bind<EnemyConfig>()
                .FromInstance(_enemyConfig)
                .AsSingle();

            Container
                .Bind<PlayerConfig>()
                .FromInstance(_playerConfig)
                .AsSingle();
        }
    }
}