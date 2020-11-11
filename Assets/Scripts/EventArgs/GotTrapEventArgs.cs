using System;
using UnityEngine;

namespace RollABall
{
    public sealed class GotTrapEventArgs
    {
        public Color Color { get; }
        public GotTrapEventArgs(Color Color)
        {
            this.Color = Color;
        }
    }
}
