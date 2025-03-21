using System;
using UnityEngine;

namespace Triggers
{
    public abstract class BaseTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerExit();
            }
        }

        protected abstract void OnPlayerEnter();
        protected abstract void OnPlayerExit();
    }
}