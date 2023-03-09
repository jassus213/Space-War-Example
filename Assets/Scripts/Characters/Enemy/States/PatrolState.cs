using Characters.Enemy;
using Player.Signals;
using UnityEngine;
using Zenject;

namespace Enemy.States
{
    public class PatrolState : State
    {
        private readonly SignalBus _signalBus;

        private Vector3 _nextPosition;
        
        

        private Vector3 _playerPosition;

        public PatrolState(EnemyFacade enemyFacade, StateMachine stateMachine) : base(enemyFacade, stateMachine)
        {
            _signalBus = stateMachine.SignalBus;
        }

        public override void Enter()
        {
            base.Enter();
            GetRandomPatrolPosition();
            Debug.Log("Enter");
            _signalBus.Subscribe<PlayerSignals.PlayerChangePos>(CheckDistanceToTarget);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _enemyFacade.MovePosition(_nextPosition);
            _enemyFacade.Rotate(_nextPosition);
            
            if (_enemyFacade.Position != _nextPosition)
                return;
            
            GetRandomPatrolPosition();
        }

        public override void Exit()
        {
            base.Exit();
            _signalBus.Unsubscribe<PlayerSignals.PlayerChangePos>(CheckDistanceToTarget);
        }

        private void CheckDistanceToTarget(PlayerSignals.PlayerChangePos args)
        {
            _playerPosition = args.PlayerPos;

            var distance = Vector3.Distance(_enemyFacade.gameObject.transform.position, _playerPosition);
            if (distance < 50)
            {
                _stateMachine.ChangeState(new FollowPlayerState(_enemyFacade, _stateMachine));
            }
        }

        private void GetRandomPatrolPosition()
        {
            //TODO Make check to Map boundaries
            var offset = Random.Range(-20, 20);
            var nextPos = new Vector3(_enemyFacade.Position.x + offset, _enemyFacade.Position.y + offset,
                _enemyFacade.Position.z);
            _nextPosition = nextPos;
        }
    }
}