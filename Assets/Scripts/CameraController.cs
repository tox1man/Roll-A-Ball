﻿using System;
using UnityEngine;

namespace RollABall
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - Player.transform.position;    
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }
    }
}