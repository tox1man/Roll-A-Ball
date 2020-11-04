using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace RollABall
{
    public abstract class Bonus : InteractiveObject, IFlayable, IFlickerable
    {
        [SerializeField] private Material _bonusMaterial;
        protected float _playerSpeed;
        protected float _flayRange;
        private float _playerSpeedBonus = 50f;

        private void Awake()
        {
            _playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>().speed;
            _bonusMaterial = GetComponent<Renderer>().material;
            if (_bonusMaterial == null)
            {
                throw new MissingFieldException($"Material missing at {name}");
            }
        }
            
        protected void DestroyBonus()
        {
            Destroy(gameObject);
        }

        protected void DisableRender()
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _flayRange),
                transform.localPosition.z);
        }

        public void Flicker()
        {

            _bonusMaterial.color = new Color(_bonusMaterial.color.r, _bonusMaterial.color.g, _bonusMaterial.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up);
        }

        protected void SlowPlayerDown()
        {
            _playerSpeed -= _playerSpeedBonus;

            Debug.Log($"Speed decreased by {_playerSpeedBonus}");
        }

        protected void SpeedPlayerUp()
        {
            _playerSpeed += _playerSpeedBonus;

            Debug.Log($"Speed increase by {_playerSpeedBonus}");
        }
    }
}
