using System;
using UnityEngine;
using Zenject;
using UniRx;
namespace Core.Data
{
   [Serializable]
   public class SerializableSettingsModel
   {
      [Range(0f, 100f)]
      public float masterVolume;
   }

   public class SettingsModel : IInitializable
   {
      private DataRepository _dataRepository;
      public ReadOnlyReactiveProperty<bool> MuteAudio { get; private set;}
      public ReactiveProperty<float> AudioVolume { get; private set;}

      public void Save()
      {
         var serializable = new SerializableSettingsModel { masterVolume = AudioVolume.Value };
         _dataRepository.SaveSettings(serializable);
      }

      [Inject]
      public SettingsModel(DataRepository dataRepository)
      {
         _dataRepository = dataRepository;
      }
      
      public void Initialize()
      {
         var settings = _dataRepository.LoadSettings();
         AudioVolume = new ReactiveProperty<float>(settings.masterVolume);
         MuteAudio = AudioVolume.Select(val => val == 0).ToReadOnlyReactiveProperty();
      }
   }
}
