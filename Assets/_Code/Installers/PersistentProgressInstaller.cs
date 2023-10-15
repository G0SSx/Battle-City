using _Code.Infrastructure.Services.Progress;
using Zenject;

namespace _Code.Installers {
	public class PersistentProgressInstaller : Installer<PersistentProgressInstaller> {
        public override void InstallBindings()
        {
            Container
                .Bind<IPersistentProgress>()
                .To<PersistentProgress>()
                .AsSingle()
                .NonLazy();
		}
    }
}