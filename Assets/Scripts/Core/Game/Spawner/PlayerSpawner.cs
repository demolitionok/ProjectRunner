using UnityEngine;
using Zenject;


public class PlayerSpawner : MonoBehaviour
{
    private Player _player;

    [Inject]
    private void Init(Player player)
    {
        _player = player;
    }

    public void Start()
    {
        _player.gameObject.SetActive(true);
    }
}