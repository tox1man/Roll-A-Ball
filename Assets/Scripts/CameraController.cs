using System;
using UnityEngine;

namespace RollABall
{
    public sealed class CameraController : IExecute
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;
        private Vector3 _offset;

        public CameraController(Transform player, Transform camera)
        {
            _playerTransform = player;
            _cameraTransform = camera;
            _cameraTransform.LookAt(_playerTransform);
            _offset = _cameraTransform.position - _playerTransform.transform.position;    
        }

        public void Execute()
        {
            _cameraTransform.position = _playerTransform.transform.position + _offset;
        }
    }
}