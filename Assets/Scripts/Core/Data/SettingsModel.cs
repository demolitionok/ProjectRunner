using System;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;
using UniRx;
namespace Core.Data
{

   [Serializable]
   public class SettingsModel : IInitializable
   {
      private DataRepository _dataRepository;

      [RangeReactiveProperty(0f, 100f)]
      [SerializeField]
      [JsonProperty]
      private FloatReactiveProperty _masterVolume;
      
      
      [JsonIgnore]
      public ReadOnlyReactiveProperty<bool> MuteAudio { get; private set;}
      [JsonIgnore]
      public FloatReactiveProperty MasterVolumeProperty { get => _masterVolume; private set => _masterVolume = value; }
      
      [Inject]
      public SettingsModel(DataRepository dataRepository)
      {
         _dataRepository = dataRepository;
      }
      
      public void Initialize()
      {
         var settings = _dataRepository.LoadSettings();
         MasterVolumeProperty = new FloatReactiveProperty(settings.MasterVolumeProperty.Value);
         MuteAudio = MasterVolumeProperty.Select(val => val == 0).ToReadOnlyReactiveProperty();
      }
   }
}
