using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{

    [CreateAssetMenu(fileName = "DataPaths", menuName = "PresetsAndConfigs/DataPaths")]
    public class DataPaths : ScriptableObject
    {
        public enum FileExtension
        {
            Json
        }
        [SerializeField]
        private FileExtension fileExtension;
        [SerializeField]
        private string _settingsFileName;
        [SerializeField]
        private string _playerDataFileName;

        private string GetExtensionString()
        {
            return fileExtension switch
            {
                FileExtension.Json => ".json",
                _ => throw new Exception()
            };
        }

        public string GetFilePathByName(string fileName) =>
            Application.persistentDataPath + "/" + fileName + GetExtensionString();

        public string SettingsFileName => _settingsFileName;
        public string PlayerDataFileName => _playerDataFileName;
        
        public string SettingsFilePath => GetFilePathByName(_settingsFileName);
        public string PlayerDataFilePath => GetFilePathByName(_playerDataFileName);
    }
}