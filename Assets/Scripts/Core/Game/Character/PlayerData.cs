using System.Collections;
using System.Collections.Generic;
using Core.Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Character.Data
{
    [System.Serializable]
    public class PlayerData
    {
        public StringReactiveProperty playerNickName;

        private IReadDataRepository _dataRepository;

        [Inject]
        public PlayerData(IReadDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void Initialize()
        {
            var playerData = _dataRepository.LoadPlayerData();
            playerNickName = new StringReactiveProperty(playerData.playerNickName.Value);
        }
    }

}
