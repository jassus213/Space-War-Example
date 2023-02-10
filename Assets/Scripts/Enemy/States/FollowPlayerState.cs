namespace Enemy
{
    public class FollowPlayerState : State
    {
        public FollowPlayerState(EnemyFacade enemyFacade, StateMachine stateMachine) : base(enemyFacade, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }
    }
}