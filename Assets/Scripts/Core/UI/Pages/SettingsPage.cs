using UnityEngine;
using UniRx;
using TMPro;
using UnityEngine.UI;
using Zenject;
using Core.Data;

namespace Core.UI.Pages
{
    public class SettingsPage : Page
    {
        private DataRepository _dataRepository;
        private SettingsModel _settings;

        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private TextMeshProUGUI _volumeValueText;

        [Header("Buttons")] [Space(10f)] int __;
        [SerializeField] private Button _backToMainMenuBtn;
        [SerializeField] private Button _saveButton;

        [Inject]
        public void Init(SettingsModel settings, DataRepository dataRepository)
        {
            _settings = settings;
            _dataRepository = dataRepository;
        }

        public override void Start()
        {
            base.Start();
            
            _settings.MasterVolumeProperty.SubscribeWithState(
                _volumeValueText,
                (volumeLevel, t) => t.text = (volumeLevel == 0) ? "Muted" : volumeLevel.ToString()
            ).AddTo(this);

            _volumeSlider.onValueChanged.AsObservable().Subscribe(
                val => _settings.MasterVolumeProperty.Value = val
            ).AddTo(this);

            _settings.MasterVolumeProperty.SubscribeWithState(
                _volumeSlider,
                (volume, slider) => slider.value = volume
            );

            _backToMainMenuBtn.onClick.AsObservable().Subscribe(
                _ => UIManager.ReplacePage<MainMenuPage>()
            ).AddTo(this);

            _saveButton.onClick.AsObservable().Subscribe(_ => _dataRepository.SaveSettings(_settings));
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}