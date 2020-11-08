using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class Buff : Bonus, IFlayable, IFlickerable
    {
        private EventHandler<CaughtPlayerEventArgs> _buffCollision;
        public EventHandler<CaughtPlayerEventArgs> BuffCollision;

        private float _bonusSpeedPenalty = 30f;

        private void Awake()
        {
            _flayRange = Random.Range(1.0f, 5.0f);
        }

        protected override void Interact()
        {
            base.SpeedPlayerUp();

            Invoke(nameof(SlowPlayerDown), 10f);
            Invoke(nameof(base.DestroyBonus), 10.01f);
        }

        public override void Execute()
        {
            Flay();
            Flicker();
        }

    }
}
