using System;
using UnityEngine;

namespace RollABall
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public int speed { get; set; }
        public bool isBuffed = false;
        public bool isDebuffed = false;

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
            if(!isDebuffed)
            {
                speed /= 2;
            }
            if (!isBuffed)
            {
                isDebuffed = true;
            }
            else
            {
                isBuffed = false;
            }
        }

        public void SpeedPlayerUp()
        {
            if (!isBuffed)
            {
                speed *= 2;
            }
            if (!isDebuffed)
            {
                isBuffed = true;
            }
            else
            {
                isDebuffed = false;
            }
        }

        public abstract void Move(float x, float y, float z);
    }
}
