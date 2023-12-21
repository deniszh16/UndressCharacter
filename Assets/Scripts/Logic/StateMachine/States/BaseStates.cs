namespace Logic.StateMachine.States
{
    public abstract class BaseStates : IState
    {
        protected readonly StateMachine _stateMachine;

        protected BaseStates(StateMachine stateMachine) =>
            _stateMachine = stateMachine;
        
        public abstract void Enter();
        public abstract void Exit();
    }
}