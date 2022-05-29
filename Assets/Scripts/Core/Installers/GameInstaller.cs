using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject uiManagerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<MainMenuSceneManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIManager>().FromComponentInNewPrefab(uiManagerPrefab).AsSingle();
            Debug.Log("Installed");
        }
    }
}
