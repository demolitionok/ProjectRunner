using UnityEngine;
using Zenject;

namespace Core.Installers
{
    [CreateAssetMenu(fileName = "EnemyInstaller", menuName = "Installers/EnemyInstaller")]
    public class EnemyInstaller : ScriptableObjectInstaller<EnemyInstaller>
    {
        public GameObject BaseEnemyPrefab;

        public override void InstallBindings()
        {
            
            Container.BindInstance(BaseEnemyPrefab).WhenInjectedInto<Enemy.CustomFactory>();
            Container
                .BindFactory<Enemy, Enemy.Factory>()
                .FromFactory<Enemy.CustomFactory>();
        }
    }
}
