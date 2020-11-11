using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Buff : Bonus, IFlayable, IFlickerable
    {
        [SerializeField] private Material _bonusMaterial;

        private event EventHandler<GotBuffEventArgs> _gotBuff;
        public event EventHandler<GotBuffEventArgs> GotBuff
        {
            add { _gotBuff += value; }
            remove { _gotBuff -= value; }
        }

        private void Awake()
        {
            _bonusMaterial = GetComponent<Renderer>().material;
            _flayRange = Random.Range(1.0f, 5.0f);
        }

        protected override void Interact()
        {
            _gotBuff?.Invoke(this, new GotBuffEventArgs(10));
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Flay();
            Flicker();
        }

        public void Flicker()
        {
            _bonusMaterial.color = new Color(_bonusMaterial.color.r, _bonusMaterial.color.g, _bonusMaterial.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _flayRange),
                transform.localPosition.z);
        }
    }
}
