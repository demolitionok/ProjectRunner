using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "PlayerDataPreset", menuName = "PresetsAndConfigs/PlayerDataPreset")]
    public class PlayerDataPreset : ScriptableObject
    {
        [SerializeField] private PlayerData _playerDataPreset;
        
        public PlayerData Preset => _playerDataPreset;
    }
}