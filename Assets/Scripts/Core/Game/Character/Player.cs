using UnityEngine;
using Zenject;
using Character.Data;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerPicker))]
public class Player : MonoBehaviour
{
    private PlayerData _playerData;
    [Inject]
    private void Init(PlayerData playerData) 
    {
        _playerData = playerData;
    }
}
