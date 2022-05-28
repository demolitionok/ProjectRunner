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
      private IReadDataRepository _dataRepository;

      [RangeReactiveProperty(0f, 100f)]
      [SerializeField]
      [JsonProperty]
      private FloatReactiveProperty _masterVolume;
      
      
      [JsonIgnore]
      public ReadOnlyReactiveProperty<bool> MuteAudio { get; private set;}
      [JsonIgnore]
      public FloatReactiveProperty MasterVolumeProperty { get => _masterVolume; private set => _masterVolume = value; }
      
      [Inject]
      public SettingsModel(IReadDataRepository dataRepository)
      {
         Debug.Log("Created new");
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
