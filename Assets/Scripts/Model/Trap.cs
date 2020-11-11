using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Trap : Bonus, IRotatable, IFlayable
    {
        private float _slowTrapSpeedPenalty = 30f;

        private event EventHandler<GotTrapEventArgs> _gotTrap;
        public event EventHandler<GotTrapEventArgs> GotTrap
        {
            add { _gotTrap += value; }
            remove { _gotTrap -= value; }
        }

        private void Awake()
        {
            _flayRange = Random.Range(1.0f,  3.0f);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Rotate();
            Flay();
        }

        protected override void Interact()
        {
            _gotTrap?.Invoke(this, new GotTrapEventArgs(this.GetComponent<Renderer>().material.color));
            Invoke(nameof(base.DestroyBonus), 10.01f);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _flayRange),
                transform.localPosition.z);
        }
    }
}
