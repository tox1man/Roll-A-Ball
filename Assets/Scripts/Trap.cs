using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Trap : Bonus, IRotatable, IFlayable
    {
        private float _slowTrapSpeedPenalty = 30f;

        private void Awake()
        {
            _flayRange = Random.Range(1.0f, 3.0f);
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
            SlowPlayerDown();

            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            Invoke(nameof(SpeedPlayerUp), 5f);
            Invoke(nameof(base.DestroyBonus), 5.01f);
        }

        public new void SlowPlayerDown()
        {
            _playerSpeed -= _slowTrapSpeedPenalty;

            Debug.Log($"Speed decreased by {_slowTrapSpeedPenalty}");
        }

        public new void SpeedPlayerUp()
        {
            _playerSpeed += _slowTrapSpeedPenalty;

            Debug.Log($"Speed increased by {_slowTrapSpeedPenalty}");
        }
    }
}
