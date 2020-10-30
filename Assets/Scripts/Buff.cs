using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Buff : Bonus, IFlayable, IFlickerable
    {
        private float _bonusSpeedPenalty = 30f;

        private void Awake()
        {
            _flayRange = Random.Range(1.0f, 5.0f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Interact();
            }
        }

        protected override void Interact()
        {
            base.SpeedPlayerUp();

            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            Invoke(nameof(SlowPlayerDown), 10f);
            Invoke(nameof(base.DestroyBonus), 10.01f);
        }

    }
}
