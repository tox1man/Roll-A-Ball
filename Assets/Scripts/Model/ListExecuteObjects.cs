using System;
using System.Collections;
using UnityEngine;

namespace RollABall
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable
    {
        private IExecute[] _interactiveObjects;
        private int _index = -1;

        public ListExecuteObjects() 
        {
            var interactiveObjects = GameObject.FindObjectsOfType<InteractiveObject>();
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    AddExecuteObject(interactiveObject);
                }
            }
        }

        public void AddExecuteObject(IExecute interactiveObject)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] { interactiveObject };
                return;
            }
            Array.Resize(ref _interactiveObjects, _interactiveObjects.Length + 1);
            _interactiveObjects[_interactiveObjects.Length - 1] = interactiveObject;
        }

        public IExecute this[int index]
        {
            get { return _interactiveObjects[index]; }
            private set { _interactiveObjects[index] = value; }
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }
            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public int Length => _interactiveObjects.Length;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
