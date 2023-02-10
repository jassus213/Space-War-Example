using Player.Signals;
using UnityEngine;
using Zenject;

namespace Enemy.States
{
    public class PatrolState : State
    {
        private readonly SignalBus _signalBus;
        private Vector3 _playerPosition;
        public PatrolState(EnemyFacade enemyFacade, StateMachine stateMachine) : base(enemyFacade, stateMachine)
        {
            _signalBus = stateMachine.SignalBus;
        }

        public override void Enter()
        {
            base.Enter();
            _signalBus.Subscribe<PlayerSignals.PlayerChangePos>(CheckDistance);
        }

        public override void Exit()
        {
            base.Exit();
            _signalBus.Unsubscribe<PlayerSignals.PlayerChangePos>(CheckDistance);
        }
        
        private void CheckDistance(PlayerSignals.PlayerChangePos args)
        {
            _playerPosition = args.PlayerPos;
            
            var distance = Vector3.Distance(_enemyFacade.gameObject.transform.position, _playerPosition);
            if (distance < 50)
            {
                _stateMachine.ChangeState(new FollowPlayerState(_enemyFacade, _stateMachine));
                Debug.Log("Follow Player State");
            }
                
        }
        
        
    }
}