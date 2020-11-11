﻿using System;
using UnityEngine;

namespace RollABall
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}
