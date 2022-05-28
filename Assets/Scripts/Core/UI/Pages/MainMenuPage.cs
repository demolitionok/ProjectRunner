using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Core.Data;
using TMPro;
using Zenject;

namespace Core.UI.Pages
{
    public class MainMenuPage : Page
    {
        [SerializeField] private Button _startBtn;
        [SerializeField] private Button _settingsBtn;
        [SerializeField] private Button _exitBtn;
        [SerializeField] private TextMeshProUGUI _audioInfoText;

        private SettingsModel _settingsModel;
        private MainMenuSceneManager _sceneManager;

        [Inject]
        private void Init(SettingsModel settingsModel, MainMenuSceneManager sceneManager)
        {
            _settingsModel = settingsModel;
            _sceneManager = sceneManager;
        }

        public override void Start()
        {
            base.Start();

            // TODO: Implement scene loading better :)
            _startBtn.onClick.AsObservable().Subscribe(_ => _sceneManager.LoadGameLevel()).AddTo(this);
            _settingsBtn.onClick.AsObservable().Subscribe(_ => UIManager.ReplacePage<SettingsPage>()).AddTo(this);
            _exitBtn.onClick.AsObservable().Subscribe(_ => Debug.Log("Should exit")).AddTo(this);
            _settingsModel.MuteAudio.SubscribeWithState( _audioInfoText, (isMuted, t) =>
            {
                if (isMuted) t.text = "Muted";
                else t.text = "Unmuted";
            }).AddTo(this);
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
