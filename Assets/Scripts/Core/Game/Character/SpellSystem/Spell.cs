using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Spell
{
    [SerializeField]
    private Sprite _icon;

    public Sprite Icon => _icon;
    public event Action OnCast;

    public void Cast()
    {
        OnCast?.Invoke();
        ApplyEffect();
    }

    protected abstract void ApplyEffect();
}
