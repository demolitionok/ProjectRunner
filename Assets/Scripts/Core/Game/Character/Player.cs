using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Character.Data;
using Character.Data.SpellSystem;
using UniRx;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerPicker))]
public class Player : MonoBehaviour, IInitializable
{
    [SerializeField] private SpellScriptable _spellScriptable;

    private Spell _spell;
    private PlayerData _playerData;

    [Inject]
    private void Init(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public void Initialize()
    {
        _spell = _spellScriptable.Spell;

        Observable
            .FromCoroutine(CastSpell)
            .Subscribe()
            .AddTo(this);
    }

    private IEnumerator CastSpell()
    {
        while (true)
        {
            yield return Observable.Timer(TimeSpan.FromSeconds(0.5d)).ToYieldInstruction();
            _spell.Cast();
        }
    }
}