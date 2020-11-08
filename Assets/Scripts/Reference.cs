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
                    var gameObject = Resources.Load<PlayerBall>("/Prefabs/Player");
                    _playerBall = gameObject;
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
                    var gameObject = Resources.Load<Camera>("/Prefabs/MainCamera");
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}
