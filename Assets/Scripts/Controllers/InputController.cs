using System;
using System.IO;
using UnityEngine;

namespace RollABall
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly XMLData _xmlData;
        private readonly SavedData _savedData;
        private readonly KeyCode _saveKey = KeyCode.C;
        private readonly KeyCode _loadKey = KeyCode.V;


        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _xmlData = new XMLData();
            _savedData = new SavedData();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if(Input.GetKeyDown(_saveKey))
            {
                _xmlData.Save(_savedData, _xmlData._savePath);
                Debug.Log("Call:" + _xmlData._savePath);
            }
        }   
    }
}
