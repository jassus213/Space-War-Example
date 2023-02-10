using Zenject;

namespace Enemy
{
    public class StateMachine
    {
        public State CurrentState;
        public SignalBus SignalBus;

        public StateMachine(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }
        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;
            newState.Enter();
        }
    }
}