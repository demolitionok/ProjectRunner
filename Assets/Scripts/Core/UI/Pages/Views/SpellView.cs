using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    [SerializeField]
    private Image _spellImage;

    public void SetupBySpell(Spell spell)
    {
        _spellImage.sprite = spell.Icon;
    }
}
