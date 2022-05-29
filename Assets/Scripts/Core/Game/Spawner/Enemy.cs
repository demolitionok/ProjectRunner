using UnityEngine;
using System;
using UniRx;
using Zenject;

public class Enemy : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
{
    private Player _player;
    private IMemoryPool _pool;

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

    public void Dispose()
    {
        _pool.Despawn(this);
    }

    public void OnDespawned()
    {
        _pool = null;
        // _velocity = Vector3.zero;
    }

    public void OnSpawned(IMemoryPool pool)
    {
        transform.position = Vector3.zero;
        _pool = pool;
        // _velocity = velocity;
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }

    public class CustomFactory : IFactory<Enemy>
    {
        private DiContainer _container;
        private GameObject _baseEnemy;

        [Inject]
        public CustomFactory(DiContainer container, GameObject baseEnemy)
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
