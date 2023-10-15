using _Code.Configs;
using _Code.Infrastructure.Services.Factories;
using _Code.Tiles.Factory;
using _Code.UI.Factory;
using UnityEngine;
using Zenject;

namespace _Code.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
		[Header("Configs")] 
        [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
        [SerializeField] private BulletConfig _bulletConfig;

		public override void InstallBindings()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

            Container.Bind<ITileFactory>().To<TileFactory>().AsSingle();

            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
		}
	}
}