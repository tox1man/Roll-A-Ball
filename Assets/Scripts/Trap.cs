using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Trap : Bonus, IRotatable, IFlayable
    {
        private float _slowTrapSpeedPenalty = 30f;

        private event EventHandler<CaughtPlayerEventArgs> _trapCollision;
        public event EventHandler<CaughtPlayerEventArgs> TrapCollision
        {
            add { _trapCollision += value; }
            remove { _trapCollision -= value; }
        }

        private void Awake()
        {
            _flayRange = Random.Range(1.0f,  3.0f);
        }

        public override void Execute()
        {
            Rotate();
            Flay();
        }

        protected override void Interact()
        {
            SlowPlayerDown();
            _trapCollision?.Invoke(this, new CaughtPlayerEventArgs(new Color(255,255,255)));

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
