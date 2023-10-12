using _Code.Infrastructure.Services.Progress;
using Zenject;

namespace _Code.Installers
{
    public class PersistentProgressInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPersistentProgress>()
                .To<PersistentProgress>()
                .AsSingle()
                .NonLazy();

            // ����� ����� ������� 25:33 �����
        }
    }
}