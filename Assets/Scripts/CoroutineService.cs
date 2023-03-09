using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        public bool IsCoroutineBusy => _isCoroutineBusy;
        private bool _isCoroutineBusy;

        public void ChangeCoroutineStatus()
        {
            _isCoroutineBusy = !_isCoroutineBusy;
        }

        public void StartCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }

    public interface ICoroutineService
    {
        bool IsCoroutineBusy { get; }
        void ChangeCoroutineStatus();
        void StartCoroutine(IEnumerator enumerator);
    }
}