using System;
using Extensions;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Character.Data.SpellSystem
{
    [Serializable]
    public class FireBall : Spell
    {
        [SerializeField] private GameObject _fireBallPrefab;

        protected override void ApplyEffect()
        {
            GameObject.Instantiate(_fireBallPrefab);
            _fireBallPrefab.GetComponent<Rigidbody2D>().AddForce(RandomGenerator.GetRandomVector2(0, -1) * 4, ForceMode2D.Force);
        }
    }
}