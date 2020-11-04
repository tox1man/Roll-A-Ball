using System;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


namespace RollABall
{
    public class GameController : MonoBehaviour
    {
        public int _score = 0;
        private InteractiveObject[] _interactiveObjects;
        private Coin[] _coins;


        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
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

                if(interactiveObject is IFlayable FlayableObject)
                {
                    FlayableObject.Flay();
                }

                if(interactiveObject is IRotatable RotatableObject)
                {
                    RotatableObject.Rotate();
                }

                if(interactiveObject is IFlickerable FlickerableObject)
                {
                    FlickerableObject.Flicker();
                }
            }
        }
    }
}
