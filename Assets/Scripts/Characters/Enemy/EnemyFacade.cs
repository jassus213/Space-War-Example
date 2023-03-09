using Characters.Common.Interfaces;
using Characters.Player.Model.Interfaces;
using Enemy;
using Enemy.States;
using UnityEngine;
using Zenject;

namespace Characters.Enemy
{
    public class EnemyFacade : MonoBehaviour, ICanGetDamage
    {
        public bool IsDead => _model.IsDead;
        public float Health => _model.Health;

        private StateMachine _stateMachine;
        private IModel _model;
        public Rigidbody2D Rigidbody => gameObject.GetComponent<Rigidbody2D>();
        public Vector3 Position => gameObject.GetComponent<Transform>().position;
        public bool IsGoes => _isGoes;
        private bool _isGoes;

        public void Construct(StateMachine stateMachine, IModel model)
        {
            _stateMachine = stateMachine;
            _model = model;
            _stateMachine.Initialize(new PatrolState(this, _stateMachine));
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
            var direction = Vector2.MoveTowards(Position, goalPos, 0.1f);
            _isGoes = true;
            Rigidbody.MovePosition(direction);
        }

        public void Rotate(Vector3 posToRotation)
        {
            var currentVector = Vector3.Lerp(transform.up, (posToRotation - transform.position), 1);
            transform.up = new Vector3(currentVector.x, currentVector.y, 0);
        }
        

        public void GetDamage(float damage)
        {
            _model.TakeDamage(damage);
        }
        
        public class Factory : PlaceholderFactory<int, EnemyFacade[]>
        {
        }
    }
}