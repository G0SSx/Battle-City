using _Code.Infrastructure.Services;
using Zenject;

namespace _Code.Installers {
	public class MathResultInstaller : Installer<MathResultInstaller> {
		public override void InstallBindings() {
			Container
				.Bind<IMatchResult>()
				.To<MatchResult>()
				.AsSingle()
				.NonLazy();
		}
	}
}