using Zenject;

namespace Core.Data
{
    public class DataRepository : IInitializable
    {
        private DataProvider<PlayerData> _playerDataProvider;
        private DataProvider<SettingsModel> _settingsDataProvider;
        private DataPaths _dataPaths;
        private SettingsPreset _settingsPreset;
        private PlayerDataPreset _playerDataPreset;

        public SettingsModel LoadSettings() => _settingsDataProvider.Load();

        public void SaveSettings(SettingsModel settingsModel) => _settingsDataProvider.Save(settingsModel);

        public PlayerData LoadPlayerData() => _playerDataProvider.Load();
        public void SavePlayerData(PlayerData data) => _playerDataProvider.Save(data);

        [Inject]
        public void Init(DataPaths dataPaths, SettingsPreset settingsPreset, PlayerDataPreset playerDataPreset)
        {
            _dataPaths = dataPaths;
            _settingsPreset = settingsPreset;
            _playerDataPreset = playerDataPreset;
        }

        public void Initialize()
        {
            _settingsDataProvider = new DataProvider<SettingsModel>(_dataPaths.SettingsFilePath);
            _playerDataProvider = new DataProvider<PlayerData>(_dataPaths.PlayerDataFilePath);

            if (LoadSettings() is null)
            {
                WriteSampleSettings();
            }

            if (LoadPlayerData() is null)
            {
                WriteSamplePlayerData();
            }
        }

        private void WriteSampleSettings()
        {
            _settingsDataProvider.Save(_settingsPreset.Preset);
        }

        private void WriteSamplePlayerData()
        {
            _playerDataProvider.Save(_playerDataPreset.Preset);
        }
    }
}