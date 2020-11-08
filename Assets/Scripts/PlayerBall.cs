using UnityEngine;


namespace RollABall
{
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _playerRigidbody;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _playerRigidbody.velocity = new Vector3(x, y, z) * speed;
        }
    }
}
