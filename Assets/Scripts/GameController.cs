using System;
using UnityEngine;


namespace RollABall
{
    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;

        private DisplayEndGame _displayEndGame;
        private DisplayScore _displayScore;
        private InputController _inputController;
        private CameraController _cameraController;
        private Reference _reference;
        private Coin[] _coins;

        public int _score = 0;


        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _reference = new Reference();
            _displayEndGame = new DisplayEndGame();
            _displayScore = new DisplayScore();
            _inputController = new InputController();
            _cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);

            _coins = FindObjectsOfType<Coin>();

            foreach (var o in _interactiveObjects)
            {
                if(o is Trap trap)
                {
                    trap.TrapCollision += CaughtPlayer;
                }
            }

        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Debug.Log($"Caught player {args.Color}");
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
                
                if (interactiveObject is IExecute ExecutableObject)
                {
                    ExecutableObject.Execute();
                }
            }
        }
    }
}
