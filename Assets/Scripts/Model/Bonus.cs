using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace RollABall
{
    public abstract class Bonus : InteractiveObject
    {
        protected float _playerSpeed;
        protected float _flayRange;

        private void Awake()
        {
            _playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>().speed;
        }
            
        protected void DestroyBonus()
        {
            Destroy(gameObject);
        }
    }
}
