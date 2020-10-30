using System;
using UnityEngine;

namespace RollABall
{
    public sealed class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            MovePlayer();
        }
    }
}
