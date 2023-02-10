using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        private State _currentState;

        private void Awake()
        {
            
        }

        private void Update()
        {
            _currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.PhysicsUpdate();
        }
        
        public class Factory : PlaceholderFactory<int, EnemyFacade[]>
        {
        }
    }
}