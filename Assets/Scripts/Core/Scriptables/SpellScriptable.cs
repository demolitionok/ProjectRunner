using System.Collections;
using System.Collections.Generic;
using Character.Data.SpellSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Spell")]
public class SpellScriptable : ScriptableObject
{
    [SerializeField]
    private FireBall _spell;

    public FireBall Spell => _spell;
}
