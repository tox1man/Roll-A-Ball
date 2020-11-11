using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Coin : Bonus, IRotatable, IFlickerable
    {
        [SerializeField] private Material _bonusMaterial;

        private event EventHandler<GotCoinEventArgs> _gotCoin;
        public event EventHandler<GotCoinEventArgs> GotCoin
        {
            add { _gotCoin += value; }
            remove { _gotCoin -= value; }
        }

        protected override void Interact()
        {
            _gotCoin?.Invoke(this, new GotCoinEventArgs());
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Rotate();
            Flicker();
        }

        private void Awake()
        {
            _bonusMaterial = GetComponent<Renderer>().material;
            _flayRange = Random.Range(0.5f, 2.5f);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.forward);
        }

        public void Flicker()
        {

            _bonusMaterial.color = new Color(_bonusMaterial.color.r, _bonusMaterial.color.g, _bonusMaterial.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
