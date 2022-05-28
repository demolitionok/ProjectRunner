using System;
using System.Collections;
using Zenject;
using UnityEngine;
using UniRx;

public class EnemySpawner : MonoBehaviour
{
    private Enemy.Factory _enemyFactory;
    private Player _player;
    [Inject]
    private void Init(Enemy.Factory enemyFactory, Player player)
    {
        _enemyFactory = enemyFactory;
        _player = player;
    }

    IEnumerator SpawnEnemies()
    {
        while (true) {
            yield return Observable.Timer(TimeSpan.FromSeconds(1)).ToYieldInstruction();
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
