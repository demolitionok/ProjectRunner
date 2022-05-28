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
            Container
                .BindFactory<Enemy, Enemy.Factory>()
                .FromComponentInNewPrefab(BaseEnemyPrefab);
        }
    }
}
