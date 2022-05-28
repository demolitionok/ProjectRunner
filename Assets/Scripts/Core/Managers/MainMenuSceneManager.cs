using UnityEngine.SceneManagement;
using Zenject;
using Core.Data;
using Core.Installers;

public class MainMenuSceneManager
{
    readonly ZenjectSceneLoader _sceneLoader;
    readonly SettingsModel _settingsModel;

    public MainMenuSceneManager(ZenjectSceneLoader sceneLoader, SettingsModel settingsModel)
    {
        _sceneLoader = sceneLoader;
        _settingsModel = settingsModel;
    }

    public void LoadGameLevel()
    {
        _sceneLoader.LoadScene("BattleScene", LoadSceneMode.Single, (container) =>
            {
                container.Bind<SettingsModel>().FromInstance(_settingsModel).WhenInjectedInto<BattleInstaller>();
            });
    }
}
