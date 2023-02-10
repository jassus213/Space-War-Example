using Enemy.States;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        #region States

        private StateMachine _stateMachine;

        #endregion

        private Rigidbody2D _rigidbody => gameObject.GetComponent<Rigidbody2D>();
        private Transform _transform => gameObject.GetComponent<Transform>();

        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _stateMachine.Initialize(new FollowPlayerState(this, _stateMachine));
        }


        private void Update()
        {
            _stateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }

        public void MovePosition(Vector2 goalPos)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, goalPos, 0.1f);
        }

        public void Rotate(Vector3 posToRotation)
        {
            transform.up = Vector3.Lerp(transform.up, (posToRotation - transform.position), 1);
        }

        public class Factory : PlaceholderFactory<int, EnemyFacade[]>
        {
        }
    }
}