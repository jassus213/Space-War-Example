using Characters.Enemy;
using Player.Signals;
using UnityEngine;
using Zenject;

namespace Enemy.States
{
    public class FollowPlayerState : State
    {
        private readonly SignalBus _signalBus;
        private Vector3 _playerPosition;

        public FollowPlayerState(EnemyFacade enemyFacade, StateMachine stateMachine) : base(enemyFacade, stateMachine)
        {
            _signalBus = stateMachine.SignalBus;
        }


        public override void Enter()
        {
            base.Enter();
            _signalBus.Subscribe<PlayerSignals.PlayerChangePos>(ChangeDestination);
        }

        public override void Exit()
        {
            base.Exit();
            _signalBus.Unsubscribe<PlayerSignals.PlayerChangePos>(ChangeDestination);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _enemyFacade.MovePosition(_playerPosition);
            _enemyFacade.Rotate(_playerPosition);
        }


        private void ChangeDestination(PlayerSignals.PlayerChangePos args)
        {
            _playerPosition = args.PlayerPos;
            
            var distance = Vector3.Distance(_enemyFacade.gameObject.transform.position, _playerPosition);
            if (distance > 50)
                _stateMachine.ChangeState(new PatrolState(_enemyFacade, _stateMachine));
        }
    }
}