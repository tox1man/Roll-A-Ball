using System;
using UnityEngine;


namespace RollABall
{
    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;


        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
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
