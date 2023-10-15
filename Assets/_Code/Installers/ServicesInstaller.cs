using _Code.Installers;
using Zenject;

namespace Assets._Code.Installers {
	public class ServicesInstaller : MonoInstaller {
		public override void InstallBindings() {
			PersistentProgressInstaller.Install(Container);
			MathResultInstaller.Install(Container);
		}
	}
}
