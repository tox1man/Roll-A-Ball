using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Coin : Bonus, IRotatable, IFlickerable
    {
        protected override void Interact()
        {
            DisableRender();
            Debug.Log("Coin");
            DestroyBonus();
        }

        private void Awake()
        {
            _flayRange = Random.Range(0.5f, 2.5f);
        }

        public new void Rotate()
        {
            transform.Rotate(Vector3.forward);
        }
    }
}
