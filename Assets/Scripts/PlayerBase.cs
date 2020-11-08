using System;
using UnityEngine;

namespace RollABall
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float speed { get; set; }

        public PlayerBase()
        {
            speed = 50f;
        }

        public PlayerBase(float speed)
        {
            this.speed = speed;
        }

        public abstract void Move(float x, float y, float z);
    }
}
