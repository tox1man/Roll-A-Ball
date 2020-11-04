using System;
using UnityEngine;

namespace RollABall
{
    public sealed class CaughtPlayerEventArgs
    {
        public Color Color { get; }
        public CaughtPlayerEventArgs(Color Color)
        {
            this.Color = Color;
        }
    }
}
