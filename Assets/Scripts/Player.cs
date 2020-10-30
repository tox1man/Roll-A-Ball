using System;
using UnityEngine;

namespace RollABall
{
    public class Player : MonoBehaviour
    {
        public float speed { get; set; }
        private Rigidbody _playerRigidbody;

        public Player()
        {
            speed = 50f;
        }

        public Player(float speed)
        {
            this.speed = speed;
        }

        private void Start()
        {
            _playerRigidbody = gameObject.GetComponent<Rigidbody>();
        }

        protected void MovePlayer()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

            _playerRigidbody.AddForce(movement * speed);
        }
    }
}
