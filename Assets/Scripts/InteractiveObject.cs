using System;
using UnityEngine;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        private bool _isInteractable;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isInteractable || !other.gameObject.CompareTag("Player"))
            {
                return;
            }
            Interact();
            IsInteractable = false;
            
        }

        private void Start()
        {
            IsInteractable = true;
        }

        protected abstract void Interact();
        public abstract void Execute();
    }
}
