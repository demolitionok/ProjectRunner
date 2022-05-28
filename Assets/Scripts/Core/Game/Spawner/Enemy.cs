using UnityEngine;
using UniRx;
using Zenject;

public class Enemy : MonoBehaviour
{
    private Player _player;

    [Inject]
    public void Init(Player player)
    {
        _player = player;
    }

    // TODO: REMOVE FROM HERE :) Ж) `;..;`
    public void Start()
    {
        var rb = GetComponent<Rigidbody2D>();

        Observable
            .EveryFixedUpdate()
            .Subscribe(_ =>
            {
                rb.velocity = (_player.transform.position - transform.position).normalized * 3;
            }).AddTo(this);
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }

    public class CustomFactory : IFactory<Enemy>
    {
        private DiContainer _container;
        private GameObject _baseEnemy;

        [Inject]
        public CustomFactory(
            DiContainer container,
            GameObject baseEnemy,
        )
        {
            _container = container;
            _baseEnemy = baseEnemy;
        }

        public Enemy Create()
        {
            return _container.InstantiatePrefabForComponent<Enemy>(_baseEnemy);
        }
    }
}
