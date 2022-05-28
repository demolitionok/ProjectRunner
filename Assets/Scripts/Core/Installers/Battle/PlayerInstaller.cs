using UnityEngine;
using Zenject;

namespace Core.Installers
{
    [CreateAssetMenu(fileName = "PlayerInstaller", menuName = "Installers/PlayerInstaller")]
    public class PlayerInstaller : ScriptableObjectInstaller<PlayerInstaller>
    {
        public GameObject playerPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<Player>()
                .FromComponentInNewPrefab(playerPrefab)
                .AsSingle();
        }
    }
}
