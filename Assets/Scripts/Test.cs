using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Assertions;

namespace DefaultNamespace
{
    public class Test : ITickable
    {
        private readonly Dictionary<int, bool> _testMap;
        private readonly ICoroutineService _coroutineService;

        public Test(ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;

            _testMap = new Dictionary<int, bool>()
            {
                { 10, true },
                { 5, false }
            };
        }

        private bool AlgorithmComplexity(int value)
        {
            return _testMap[value];
        }

        private IEnumerator UnitTest()
        {
            ChangeCoroutineStatus();
            Assert.AreEqual(true, AlgorithmComplexity(10));
            yield return new WaitForSeconds(5);
            ChangeCoroutineStatus();
        }

        public void Tick()
        {
            if (!_coroutineService.IsCoroutineBusy)
                _coroutineService.StartCoroutine(UnitTest());
        }

        private void ChangeCoroutineStatus()
        {
            _coroutineService.ChangeCoroutineStatus();
        }
    }
}