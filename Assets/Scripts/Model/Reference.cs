using System;
using UnityEngine;


namespace RollABall
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        
        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var playerObject = Resources.Load<PlayerBall>("Prefabs/Player");
                    _playerBall = GameObject.Instantiate(playerObject);
                }
                return _playerBall;
            }
        }
        
        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}
