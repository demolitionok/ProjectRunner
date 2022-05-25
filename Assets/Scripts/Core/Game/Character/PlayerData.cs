using System.Collections;
using System.Collections.Generic;
using Core.Data;
using UniRx;
using UnityEngine;
using Zenject;

[System.Serializable]
public class PlayerData
{
    public StringReactiveProperty playerNickName;

    private DataRepository _dataRepository;
    
    [Inject]
    public PlayerData(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }
      
    public void Initialize()
    {
        var playerData = _dataRepository.LoadPlayerData();
        playerNickName = new StringReactiveProperty(playerData.playerNickName.Value);
    }
}
