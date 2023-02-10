namespace Enemy
{
    public abstract class State
    {
        protected EnemyFacade _enemyFacade;
        protected StateMachine _stateMachine;
        
        protected State(EnemyFacade enemyFacade, StateMachine stateMachine)
        {
            _enemyFacade = enemyFacade;
            _stateMachine = stateMachine;
        }
        
        public virtual void Enter()
        {
            
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}