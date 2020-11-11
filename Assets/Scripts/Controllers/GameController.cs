using System;
using UnityEngine;


namespace RollABall
{
    public class GameController : MonoBehaviour
    {
        public ListExecuteObjects _interactiveObjects;

        private Reference _reference;
        private PlayerBall _player;
        private CameraController _cameraController;
        private InputController _inputController;
        private DisplayScore _displayScore;
        private DisplayEndGame _displayEndGame;

        public int _gameScore = 0;

        private void Awake()
        {
            _interactiveObjects = new ListExecuteObjects();

            _reference = new Reference();
            _player = _reference.PlayerBall;

            _inputController = new InputController(_reference.PlayerBall);
            _interactiveObjects.AddExecuteObject(_inputController);

            _cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            _displayScore = new DisplayScore();
            _displayEndGame = new DisplayEndGame();

            foreach (var o in _interactiveObjects)
            {
                if (o is Trap trap)
                {
                    trap.GotTrap += OnTrapPickUp;
                }
                if (o is Coin coin)
                {
                    coin.GotCoin += OnCoinPickUp;
                }
                if (o is Buff buff)
                {
                    buff.GotBuff += OnBuffPickUp;
                }
            }

        }

        private void OnTrapPickUp(object value, GotTrapEventArgs trapArgs)
        {
            _player.SlowPlayerDown();
            Debug.Log($"Slown down by trap {trapArgs.Color}");
        }

        private void OnCoinPickUp(object value, GotCoinEventArgs coinArgs)
        {
            _gameScore++;
            Debug.Log($"{_gameScore} coins collected!");
        }

        private void OnBuffPickUp(object value, GotBuffEventArgs buffArgs)
        {
            _player.SpeedPlayerUp();
            Debug.Log($"Speed buff");
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
    }
}
