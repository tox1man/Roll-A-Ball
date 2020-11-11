using System;
using UnityEngine;

namespace RollABall
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public int speed { get; set; }

        public PlayerBase()
        {
            speed = 5;
        }

        public PlayerBase(int speed)
        {
            this.speed = speed;
        }
        public void SlowPlayerDown()
        {
            speed /= 2;
        }

        public void SpeedPlayerUp()
        {
            speed *= 2;
        }

        public abstract void Move(float x, float y, float z);
    }
}
