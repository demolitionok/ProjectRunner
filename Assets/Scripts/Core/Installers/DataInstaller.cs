using Core.Data;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Installers/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        [SerializeField] private DataPaths _dataPathsConfig;

        [SerializeField] private SettingsPreset _settingsPreset;

        [SerializeField] private PlayerDataPreset _playerDataPreset;

        public override void InstallBindings()
        {
            Container.Bind<DataPaths>().FromInstance(_dataPathsConfig).AsSingle();
            Container.Bind<SettingsPreset>().FromInstance(_settingsPreset).AsSingle();
            Container.Bind<PlayerDataPreset>().FromInstance(_playerDataPreset).AsSingle();
            
            Container.BindInterfacesAndSelfTo<DataRepository>().AsSingle();

            Container.BindInterfacesAndSelfTo<SettingsModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerData>().AsSingle();
        }
    }
}
