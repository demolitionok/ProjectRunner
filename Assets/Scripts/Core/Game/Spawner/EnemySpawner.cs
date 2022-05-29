using System;
using System.Collections;
using Zenject;
using UnityEngine;
using UniRx;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn rate in seconds")] [SerializeField]
    private float _spawnRate = 1f;

    private Enemy.Factory _enemyFactory;
    private Player _player;

    [Inject]
    private void Init(Enemy.Factory enemyFactory, Player player)
    {
        _enemyFactory = enemyFactory;
        _player = player;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return Observable.Timer(TimeSpan.FromSeconds(_spawnRate)).ToYieldInstruction();
            var enemy = _enemyFactory.Create();
            enemy.transform.position = _player.transform.position + new Vector3(3, 3, 0);
        }
    }

    public void Start()
    {
        Observable
            .FromCoroutine(SpawnEnemies)
            .Subscribe()
            .AddTo(this);
    }
}