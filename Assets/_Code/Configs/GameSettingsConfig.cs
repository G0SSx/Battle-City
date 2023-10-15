using UnityEngine;
using Zenject;

namespace _Code.Configs {
	[CreateAssetMenu(menuName = "Configs/GameSettings", fileName = "GameSettings")]
	public class GameSettingsConfig : ScriptableObjectInstaller<GameSettingsConfig> {
        public BulletConfig BulletConfig;
        public EnemyConfig EnemyConfig;
        public EnemySpawnerConfig EnemySpawnerConfig;
        public PlayerConfig PlayerConfig;

        public override void InstallBindings() {
			Container.BindInstances(BulletConfig, EnemyConfig, EnemySpawnerConfig, PlayerConfig);
		}
	}
}