using UnityEngine;
using Zenject;
using Core.Data;

namespace Core.Installers
{
    [CreateAssetMenu(fileName = "BattleInstaller", menuName = "Installers/BattleInstaller")]
    public class BattleInstaller : ScriptableObjectInstaller<BattleInstaller>
    {
        private SettingsModel _settings;
        [Inject]
        private void Init([InjectOptional]SettingsModel settingsModel) {
            _settings = settingsModel;
        }

        public override void InstallBindings()
        {
            if (_settings is { })
            {
                Container.Bind<SettingsModel>().FromInstance(_settings).AsSingle();
                Debug.Log($"Installed `{nameof(SettingsModel)}` from instance");
            }
            else
            {
                Container.Bind<SettingsModel>().AsSingle();
                Debug.Log($"Installed `{nameof(SettingsModel)}` from new");
            }
        }
    }
}
